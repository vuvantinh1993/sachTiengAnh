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
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExtraoneServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExtraoneServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ExtraoneServiceModel model);
    }

    public class ExtraoneService : IExtraoneService
    {
        private readonly ILogger<ExtraoneService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public ExtraoneService(ILogger<ExtraoneService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
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
                x.answerWrongVn
            }).AsQueryable();

            //// Hàm chuyReadFolderAndThenUploadDBAndCopyFile
            //ReadFolderAndThenUploadDBAndCopyFile();

            //// Update vào 2 trường answerWrongEn và answerWrongVn trong DB
            //var listId = _db.Extraone.Select(x => x.id).ToList();

            //foreach (var i in listId)
            //{
            //    UpdateAnserWrong(i);
            //}

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



        // Đọc toàn bộ thư mục rồi lưu vào database và copy sang thư mục khác
        public void ReadFolderAndThenUploadDBAndCopyFile(string targetDirectory = "C:\\Users\\TINHVU\\Desktop\\extra2\\filecut")
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);

            var listFileName = new string[30];

            foreach (string fileName in fileEntries)
            {
                var name = fileName.Substring(fileName.IndexOf("t\\") + 2);
                var stt = name.Substring(0, name.IndexOf('.'));
                listFileName[Convert.ToInt32(stt)] = fileName;
            }


            foreach (string fileName in listFileName)
            {
                if (fileName != null)
                {
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "extraOne");

                    // cắt chuỗi textVN và TextEN
                    var name = fileName.Substring(fileName.IndexOf("t\\") + 2);
                    var stt = name.Substring(0, name.IndexOf('.'));
                    var textEn = name.Substring(name.IndexOf('.') + 1, name.IndexOf('-') - name.IndexOf('.') - 2);
                    var textVn = name.Substring(name.IndexOf('-') + 2);

                    // chỉnh sửa đường dẫn cho url
                    var fullName = Regex.Replace(textEn, @"[\.\!\s\,\-\+\?\`]", "_");
                    fullName = Regex.Replace(fullName, @"_$", "");
                    fullName = Regex.Replace(fullName, @"[\']", "");

                    textVn = textVn.Substring(0, textVn.Length - 4);

                    // Kiểm tra nếu cuối câu trả lời có dấu '`' thì nó là câu hỏi, cần thêm dấu '?' vào cuối câu
                    var checkQuest = textVn[textVn.Length - 1];
                    if (checkQuest == '`')
                    {
                        textEn = textEn + '?';
                        textVn = textVn.Substring(0, textVn.Length - 1) + '?';
                    }

                    // fullname, urlaudio
                    var guid = Guid.NewGuid().ToString();
                    var fileNameNew = $"{stt}_{guid}_{fullName}" + ".mp4";
                    fullName = $"/files/extraOne/{fileNameNew}";
                    var urlaudio = $"http://localhost:5000{fullName}";
                    var stream = Path.Combine(folderPath, fileNameNew);

                    File.Copy(fileName, stream);

                    var data = new Extraone();
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

                }
            }
        }

        // Update vào 2 trường answerWrongEn và answerWrongVn trong DB
        public void UpdateAnserWrong(int Idstt)
        {
            List<int> checkId = new List<int>();
            var listId = _db.Extraone.Where(x => x.id != Idstt).Select(x => x.id).ToList();
            var data = _db.Extraone.FirstOrDefault(x => x.id == Idstt);

            Random ran = new Random();
            int mynum = ran.Next(listId.Min(), listId.Max());
            string listStringEn = _db.Extraone.Where(x => x.id == mynum).FirstOrDefault().textEn;
            string listStringVn = _db.Extraone.Where(x => x.id == mynum).FirstOrDefault().textVn;

            for (int i = 0; i < 6; i++)
            {
                while (checkId.Contains(mynum))
                {
                    mynum = ran.Next(listId.Min(), listId.Max());
                }
                if (i != 0)
                {
                    var textEn = _db.Extraone.Where(x => x.id == mynum).FirstOrDefault().textEn;
                    var textVn = _db.Extraone.Where(x => x.id == mynum).FirstOrDefault().textVn;
                    listStringEn = listStringEn + " *** " + textEn;
                    listStringVn = listStringVn + " *** " + textVn;
                }
                checkId.Add(mynum);
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
    }
}
