using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTIN.Domain.Services
{
    public interface IExtraoneService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> GetWord(string style, int idfilm, Search_ExtraoneServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExtraoneServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExtraoneServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ExtraoneServiceModel model);
        void updatedanhsachtuvaoDB();
    }

    public class ExtraoneService : IExtraoneService
    {
        private readonly ILogger<ExtraoneService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly IRankService _rankService;

        public ExtraoneService(ILogger<ExtraoneService> log, NATemplateContext db, ICurrentUserService currentUserService, IRankService rankService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _rankService = rankService;
        }


        /// <summary>
        /// Lấy list câu hỏi về tạo bài học
        /// </summary>
        /// <param name="style"> là kiểu học 'new' hay học lại nhận 2 giá trị "new và old"</param>
        /// <param name="idfilm">id của bộ phim</param>
        /// <param name="model">điều kiện where</param>
        /// <returns></returns>
        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> GetWord(string style, int idfilm, Search_ExtraoneServiceModel model)
        {
            var aaaaa = _currentUserService;
            var userId = "be26f6c3-9942-4cb8-bd03-c117e33d4283";
            if (style == "new")
            {
                var errors = new List<ErrorModel>();

                // trả về vị trí từ đang học của film
                var rs = positionWordStop(userId, idfilm);
                if (rs.sttWord == -2)
                {
                    return (null, rs.errors, new PagingModel { });
                }
                else
                {
                    var statusActive = (int)StatusDb.Nomal;
                    var statusHide = (int)StatusDb.Hide;
                    var stt = rs.sttWord;
                    if (stt <= 1)
                    {
                        if (stt == -1)
                        {
                            model.size = 4;
                        }
                        else
                        {
                            stt = 1;
                        }
                    }
                    var query = _db.Extraone
                        .Where(x => x.categoryfilmid == idfilm)
                        .Where(x => x.stt >= stt)
                        .Where(x => (int)DbFunction.JsonValue(x.categoryfilm.dataDb, "$.status") != 3)
                        .AsQueryable();

                    if (model.where != null)
                    {
                        query = query.WhereLoopback(model.whereLoopback);

                        if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                        {
                            query = query.Where(x =>
                           (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                        }
                    }
                    else
                    {
                        query = query.Where(x =>
                           (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                    }

                    query = query.OrderByLoopback(model.orderLoopback);
                    var result = query.Select(x => new
                    {
                        x.id,
                        x.textVn,
                        x.textEn,
                        x.stt,
                        x.urlaudio,
                        x.answerWrongEn,
                        x.answerWrongVn,
                        x.categoryfilmid,
                        namefilm = x.categoryfilm.name,
                        pointfilm = x.categoryfilm.pointword,
                        x.categoryfilm.level,
                        x.categoryfilm.totalWord
                    }).ToPaging(model);
                    return (new { result.data, rs.sttWord }, errors, result.paging);
                }
            }
            else if (style == "old")
            {
                //giá trị truyền lên là old
                var errors = new List<ErrorModel>();
                var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.userId == userId);
                var a = data.filmpunishing.FirstOrDefault(y => y.filmid == idfilm).wordleaned;
                var b = data.filmforgeted.FirstOrDefault(y => y.filmid == idfilm).wordleaned;
                var c = data.filmfinish.FirstOrDefault(y => y.filmid == idfilm).wordleaned.Where(z => z.isforget == 1);
                var d = a.Concat(b).Concat(c).OrderBy(x => x.check).ToList();

                var query = _db.Extraone
                        .Where(x => x.categoryfilmid == idfilm)
                        .Where(t => d.Select(x => x.stt).Contains(t.stt));

                if (model.where != null)
                {
                    query = query.WhereLoopback(model.whereLoopback);
                }
                query = query.OrderByLoopback(model.orderLoopback);

                var result = query.Select(x => new
                {
                    x.id,
                    x.textVn,
                    x.textEn,
                    x.stt,
                    x.urlaudio,
                    x.answerWrongEn,
                    x.answerWrongVn,
                    x.categoryfilmid,
                    namefilm = x.categoryfilm.name,
                    pointfilm = x.categoryfilm.pointword,
                    x.categoryfilm.level,
                    x.categoryfilm.totalWord,
                    iteam = d.FirstOrDefault(n => n.stt == x.stt)

                }).ToPaging(model);

                return (new { result.data, sttWord = -3 }, errors, result.paging);
            }

            return (null, null, new PagingModel { });
        }


        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.Extraone.Select(x => new
            {
                x.id,
                x.textVn,
                x.textEn,
                x.dataDb,
                x.urlaudio,
                x.answerWrongEn,
                x.answerWrongVn,
                x.categoryfilmid,
                x.stt
            }).AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);

        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "extraOne");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            var guid = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(model.audio.FileName);
            var fileName = $"{guid}_{ model.fullName}" + extension;
            var filePath = Path.Combine(folderPath, fileName);
            using (var stream = File.Create(filePath))
            {
                await model.audio.CopyToAsync(stream);
            }
            model.fullName = $"/files/extraOne/{fileName}";

            var data = new Extraone();
            if (model.audio != null)
            {
                data.textEn = model.textEn;
                data.textVn = model.textVn;
                data.fullName = model.fullName;
                data.urlaudio = model.domain + model.fullName;
                data.size = model.audio.Length;
            }

            data.dataDb = new DataDbJson
            {
                createdBy = Int32.Parse(_currentUserService.userId),
                createdDate = DateTime.Now
            };
            _db.Extraone.Add(data);
            await _db.SaveChangesAsync();
            return (data, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            model.id = id;
            var update = data.Patch(model);
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.dataDb.modifiedBy = Int32.Parse(_currentUserService.userId);
            update.dataDb.modifiedDate = DateTime.Now;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = new
            {
                dataDb = new
                {
                    status = (int)StatusDb.Delete,
                    model.delectationTime,
                    model.delectationBy
                }
            };
            _db.Entry(data).CurrentValues.SetValues(data.Patch(update));

            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "Extraone delete fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.Extraone.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.Extraone.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }


        /// <summary>
        /// Tìm vị trí đang học của từ đó tương ứng với film cần tìm nếu chưa có thì nó là -1
        /// </summary>
        /// <param name="userId">Id của người dùng</param>
        /// <param name="idFilm">Id của film</param>
        /// <returns>Trả về vị trí của từu cần học trong phim, nếu chưa có thì tạo mới gán giá trị bằng -1, còn -2 là lỗi</returns>
        public (int sttWord, List<ErrorModel> errors) positionWordStop(string userId, int idFilm)
        {
            var errors = new List<ErrorModel>();
            var data = _db.UserLeanning.FirstOrDefault(x => x.userId == userId);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "NotExitUser", value = "Không tồn tại người dùng" });
                return (-2, errors);
            }
            else
            {
                // nếu chưa có thì tạo mới 1 object film
                if (data.filmleanning == null)
                {
                    var update = data.JsonToString().JsonToObject<UserLeanning>();
                    var filmlean = new userfilmleanningDataJson
                    {
                        filmid = idFilm,
                        sttWord = -1,
                        wordleaned = new List<wordleanedDataJson> { }
                    };
                    update.filmleanning = new List<userfilmleanningDataJson>();
                    update.filmforgeted = new List<userfilmleanningDataJson>();
                    update.filmpunishing = new List<userfilmleanningDataJson>();
                    update.filmfinish = new List<userfilmleanningDataJson>();
                    update.filmleanning.Add(filmlean);
                    update.filmforgeted.Add(filmlean);
                    update.filmpunishing.Add(filmlean);
                    update.filmfinish.Add(filmlean);
                    _db.Entry(data).CurrentValues.SetValues(update);


                    // Them 1 người mới vào category film
                    var categ = _db.Categoryfilm.FirstOrDefault(x => x.id == idFilm);
                    if (categ != null)
                    {
                        var updatecate = new
                        {
                            totalUser = categ.totalUser + 1
                        };
                        _db.Entry(categ).CurrentValues.SetValues(categ.Patch(updatecate));
                        if (_db.SaveChanges() > 0)
                        {
                            return (-1, errors);
                        }
                    }
                    errors.Add(new ErrorModel { key = "AddFilm", value = "Không thể thêm được film" });
                    return (-2, errors);

                }
                else
                {
                    //kiểm tra bên trong có film đó chưa
                    foreach (var item in data.filmleanning)
                    {
                        if (item.filmid == idFilm)
                        {
                            return (item.sttWord, errors);
                        }
                        else
                        {
                            var newfilm = new userfilmleanningDataJson();
                            newfilm.filmid = idFilm;
                            newfilm.sttWord = -1;
                            newfilm.wordleaned = new List<wordleanedDataJson> { };
                            _db.Entry(data).CurrentValues.SetValues(data.Patch(newfilm));

                            // Them 1 người mới vào category film
                            var categ = _db.Categoryfilm.FirstOrDefault(x => x.id == idFilm);
                            if (categ != null)
                            {
                                var updatecate = new
                                {
                                    totalUser = categ.totalUser + 1
                                };
                                _db.Entry(categ).CurrentValues.SetValues(categ.Patch(updatecate));
                                if (_db.SaveChanges() > 0)
                                {
                                    return (newfilm.sttWord, errors);
                                }
                            }
                            errors.Add(new ErrorModel { key = "AddFilm", value = "Không thể thêm được film" });
                            return (-2, errors);
                        }
                    }
                }
            }
            return (-2, errors);
        }


        public void updatedanhsachtuvaoDB()
        {
            //// Hàm chuyReadFolderAndThenUploadDBAndCopyFile
            //ReadFolderAndThenUploadDBAndCopyFile();

            // Update vào 2 trường answerWrongEn và answerWrongVn trong DB
            var listId = _db.Extraone.Where(x => x.categoryfilmid == 1).Select(x => x.id).ToList();
            foreach (var i in listId)
            {
                UpdateAnserWrong(i);
            }

            //// Update table Rank
            //updateTableRank("C:\\Users\\TINHVU\\Desktop\\extra1\\rank.txt");

        }



        // Đọc toàn bộ thư mục video rồi lưu vào database và copy sang thư mục khác
        public void ReadFolderAndThenUploadDBAndCopyFile(string targetDirectory = "C:\\Users\\TINHVU\\Desktop\\extra1\\filecut2")
        {
            // Process the list of files found in the directory.
            DirectoryInfo di = new DirectoryInfo("C:\\Users\\TINHVU\\Desktop\\extra1\\filecut2");
            var a = di.GetFiles();
            FileInfo[] fileEntries = di.GetFiles();
            //string[] fileEntries = Directory.GetFiles(targetDirectory);
            int stt = 1;

            foreach (var file in fileEntries)
            {
                if (file != null)
                {
                    var fileName = file.FullName;
                    var size = file.Length;
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "extraOne");

                    // cắt chuỗi textVN và TextEN
                    var name = Regex.Replace(fileName, ".*\\\\", "");
                    var textEn = name.Substring(name.IndexOf('.') + 1, name.IndexOf('-') - name.IndexOf('.') - 2);
                    var textVn = name.Substring(name.IndexOf('-') + 2);


                    // chỉnh sửa đường dẫn cho url
                    //var fullName = Regex.Replace(textEn, @"[\.\!\s\,\-\+\?\`]", "_");
                    var fullName = Regex.Replace(textEn, @"_$", "");
                    fullName = Regex.Replace(fullName, @"[\']", "");

                    textVn = textVn.Substring(0, textVn.Length - 4);
                    textEn = Regex.Replace(textEn, @"_$", "");
                    textEn = Regex.Replace(textEn, "_", " ");
                    textEn = Regex.Replace(textEn, "`", "?");
                    textVn = Regex.Replace(textVn, @"_$", "");
                    textVn = Regex.Replace(textVn, "_", " ");
                    textVn = Regex.Replace(textVn, "`", "?");

                    //// Kiểm tra nếu cuối câu trả lời có dấu '`' thì nó là câu hỏi, cần thêm dấu '?' vào cuối câu
                    //var checkQuest = textVn[textVn.Length - 1];
                    //if (checkQuest == '`')
                    //{
                    //    textEn = textEn + '?';
                    //    textVn = textVn.Substring(0, textVn.Length - 1) + '?';
                    //}

                    // fullname, urlaudio
                    var guid = Guid.NewGuid().ToString();
                    var fileNameNew = $"{stt}_{guid}_{fullName}" + ".mp4";
                    fullName = $"/files/extraOne/{fileNameNew}";
                    var urlaudio = $"http://localhost:5000{fullName}";
                    var stream = Path.Combine(folderPath, fileNameNew);

                    File.Copy(fileName, stream);

                    var data = new Extraone();
                    data.categoryfilmid = 1;
                    data.size = size;
                    data.textEn = textEn;
                    data.textVn = textVn;
                    data.fullName = fullName;
                    data.urlaudio = urlaudio;
                    data.stt = Convert.ToInt32(stt);
                    data.dataDb = new DataDbJson
                    {
                        createdBy = Int32.Parse(_currentUserService.userId),
                        createdDate = DateTime.Now
                    };
                    _db.Extraone.Add(data);
                    _db.SaveChanges();
                    stt = stt + 1;
                }
            }
        }

        // Update vào 2 trường answerWrongEn và answerWrongVn trong DB
        public void UpdateAnserWrong(int Idstt)
        {
            List<int> checkId = new List<int>();
            var listId = _db.Extraone.Where(x => x.id != Idstt).Select(x => x.id).ToList();
            var data = _db.Extraone.FirstOrDefault(x => x.id == Idstt);

            var random = new Random();
            int index = random.Next(listId.Count);

            string listStringEn = _db.Extraone.Where(x => x.id == listId[index]).FirstOrDefault().textEn;
            string listStringVn = _db.Extraone.Where(x => x.id == listId[index]).FirstOrDefault().textVn;

            for (int i = 0; i < 6; i++)
            {
                while (checkId.Contains(listId[index]))
                {
                    index = random.Next(listId.Count);
                }
                if (i != 0)
                {
                    var textEn = _db.Extraone.Where(x => x.id == listId[index]).FirstOrDefault().textEn;
                    var textVn = _db.Extraone.Where(x => x.id == listId[index]).FirstOrDefault().textVn;
                    listStringEn = listStringEn + " *** " + textEn;
                    listStringVn = listStringVn + " *** " + textVn;
                }
                checkId.Add(listId[index]);
            }
            var update = new
            {
                answerWrongEn = listStringEn,
                answerWrongVn = listStringVn
            };
            var model = data.Patch(update);
            _db.Entry(data).CurrentValues.SetValues(model);
            _db.SaveChanges();
        }

        public void updateTableRank(string path)
        {
            string stringFile = File.ReadAllText(path);
            List<string> arrlinetext = new List<string>(stringFile.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            if (arrlinetext.Count() > 0)
            {
                for (int i = 0; i < arrlinetext.Count(); i++)
                {
                    var m = i;
                    var item = arrlinetext[m].Split('|');
                    if (item.Count() == 3)
                    {
                        var data = new Rank();
                        data.dataDb = new DataDbJson()
                        {
                            status = 1,
                            createdBy = Int32.Parse(_currentUserService.userId),
                            createdDate = DateTime.Now
                        };
                        //var b = a.Patch(update);
                        data.name = item[0];
                        data.star = Convert.ToInt32(item[1]);
                        data.pointStage = Convert.ToInt32(item[2]);
                        _db.Rank.Add(data);
                        _db.SaveChanges();
                    }
                }

            }
        }

    }
}
