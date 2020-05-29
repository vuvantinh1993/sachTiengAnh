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
    public interface IWordFilmService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> GetWord(string style, Search_WordFilmServiceModel model, int idfilm = 0);
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_WordFilmServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_WordFilmServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> AddFeedBackWord(int id, FeedBackaboutWord model);
        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_WordFilmServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_WordFilmServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_WordFilmServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_WordFilmServiceModel model);
    }

    public class WordFilmService : IWordFilmService
    {
        private readonly ILogger<WordFilmService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly IRankService _rankService;

        public WordFilmService(ILogger<WordFilmService> log, NATemplateContext db, ICurrentUserService currentUserService, IRankService rankService)
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
        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> GetWord(string style, Search_WordFilmServiceModel model, int idfilm = 0)
        {
            var userId = _currentUserService.userId;
            var errors = new List<ErrorModel>();
            // kiểm tra từ đang học là học mới hay học lại
            // lấy vị trí của từ đang học
            var rs = positionWordStop(userId, idfilm);
            if (style == "new")
            {
                // Nếu số thứ tự trả về là -2 có nghia là lỗi
                if (rs.sttWord == -2)
                {
                    return (null, rs.errors, new PagingModel { });
                }
                var statusActive = (int)StatusDb.Nomal;
                var stt = rs.sttWord;
                if (stt == -1) { model.size = 4; } // film học lần đầu tiên lấy 4 bản ghi

                var query = _db.WordFilm
                    .Where(x => x.categoryfilmid == idfilm)
                    .Where(x => x.stt >= stt)
                    .Where(x => (int)DbFunction.JsonValue(x.categoryfilm.dataDb, "$.status") == statusActive)
                    .AsQueryable();
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
                    x.categoryfilm.totalWord
                }).ToPaging(model);
                return (new { result.data, rs.sttWord, rs.speedVideo }, errors, result.paging);
            }
            else if (style == "old")
            {
                //giá trị truyền lên là old
                var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.userId == userId);
                if (data == null)
                {
                    errors.Add(new ErrorModel { key = "getWordOld", value = "Không tồn tại người dùng" });
                    return (null, errors, null);
                }
                else
                {
                    var d = new List<wordleanedJson>();

                    if (idfilm == 0)
                    {
                        // lấy 20 từ về cho học nhanh
                        // học từ đã quên của film đưa lên
                        if (data.filmPunishing != null)
                        {
                            var a = data.filmPunishing;
                            d = a.ToList();
                        }
                        if (d.Count < 20 && data.filmForgeted != null)
                        {
                            var b = data.filmForgeted;
                            d = d.Concat(b).ToList();
                        }
                        if (d.Count < 20 && data.filmFinishForget != null)
                        {
                            var b = data.filmFinishForget;
                            d = d.Concat(b).ToList();
                        }
                        // lấy tốc dộ video
                        var speedVideo = rs.speedVideo;

                        var query = _db.WordFilm
                                .Where(x => x.categoryfilmid == idfilm)
                                .Where(t => d.Select(x => x.idWord).Contains(t.id));
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
                            iteam = d.FirstOrDefault(n => n.idWord == x.id)
                        }).ToPaging(model);
                        return (new { result.data, sttWord = -3, rs.speedVideo }, errors, result.paging);
                    }
                    else
                    {
                        // học từ đã quên của film đưa lên
                        if (data.filmPunishing != null)
                        {
                            var a = data.filmPunishing.Where(y => y.idfilm == idfilm);
                            d = a.ToList();
                        }
                        if (d.Count < 5 && data.filmForgeted != null)
                        {
                            var b = data.filmForgeted.Where(y => y.idfilm == idfilm);
                            d = d.Concat(b).ToList();
                        }
                        if (d.Count < 5 && data.filmFinishForget != null)
                        {
                            var b = data.filmFinishForget.Where(y => y.idfilm == idfilm);
                            d = d.Concat(b).ToList();
                        }
                        // lấy tốc dộ video
                        var speedVideo = rs.speedVideo;

                        var query = _db.WordFilm
                                .Where(x => x.categoryfilmid == idfilm)
                                .Where(t => d.Select(x => x.idWord).Contains(t.stt));
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
                            iteam = d.FirstOrDefault(n => n.idWord == x.id)
                        }).ToPaging(model);
                        return (new { result.data, sttWord = -3, rs.speedVideo }, errors, result.paging);
                    }
                }
            }
            return (null, null, new PagingModel { });
        }

        /// <summary>
        /// Tìm vị trí đang học của từ đó tương ứng với film cần tìm nếu chưa có thì nó là -1
        /// </summary>
        /// <param name="userId">Id của người dùng</param>
        /// <param name="idfilm">Id của film</param>
        /// <returns>Trả về vị trí của từu cần học trong phim, nếu chưa có thì tạo mới gán giá trị bằng -1, còn -2 là lỗi</returns>
        private (int sttWord, double speedVideo, List<ErrorModel> errors) positionWordStop(string userId, int idfilm)
        {
            var errors = new List<ErrorModel>();
            var data = _db.UserLeanning.FirstOrDefault(x => x.userId == userId);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "NotExitUser", value = "Không tồn tại người dùng" });
                return (-2, 1.0, errors);
            }
            else
            {
                var dataClone = data.JsonToString().JsonToObject<UserLeanning>();
                if (data.listFilmLearned == null)
                {
                    // Lưu thêm phim mới đó ở đây
                    var rs = CreateFilmAndAddUser(data, dataClone, idfilm);
                    return (rs.sttWord, rs.speedVideo, rs.errors);
                }
                else
                {
                    //kiểm tra bên trong có film đó chưa
                    foreach (var item in dataClone.listFilmLearned)
                    {
                        if (item.filmid == idfilm)
                        {
                            return (item.sttWord, item.speedVideo, errors);
                        }
                    }
                    // nếu chưa có phim đó sẽ tạo thêm film mới ở đây
                    var rs = CreateFilmAndAddUser(data, dataClone, idfilm);
                    return (rs.sttWord, rs.speedVideo, rs.errors);
                }
            }
        }

        /// <summary>
        /// Thêm mới 1 bộ phim bắt đầu học cho ng đó
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataClone"></param>
        /// <param name="idfilm">id của bộ phim</param>
        /// <returns></returns>

        private (int idWord, int sttWord, double speedVideo, List<ErrorModel> errors) CreateFilmAndAddUser(UserLeanning data, UserLeanning dataClone, int idfilm)
        {
            var errors = new List<ErrorModel>();
            var wordFirstOfFilm = _db.WordFilm.FirstOrDefault(x => x.categoryfilmid == idfilm);
            if (wordFirstOfFilm == null)
            {
                errors.Add(new ErrorModel { key = "AddFilm", value = "Film này ko có trong cơ sở dữ liệu" });
                return (0, -2, 1.0, errors);
            }

            var filmlean = new filmlearnedJson
            {
                filmid = idfilm,
                sttWord = -1,
                isFinish = false,
                speedVideo = 1.0,
                removedWords = new List<int>(),
            };

            dataClone.listFilmLearned = new List<filmlearnedJson>();
            dataClone.listFilmLearned.Add(filmlean);
            _db.Entry(data).CurrentValues.SetValues(dataClone);

            //Them 1 người mới vào category film
            var categ = _db.Categoryfilm.FirstOrDefault(x => x.id == idfilm);
            if (categ != null)
            {
                var updatecate = new
                {
                    totalUser = categ.totalUser + 1
                };
                _db.Entry(categ).CurrentValues.SetValues(categ.Patch(updatecate));
                if (_db.SaveChanges() > 0)
                {
                    return (wordFirstOfFilm.id, -1, 1.0, errors);
                }
            }
            errors.Add(new ErrorModel { key = "AddFilm", value = "Không thể thêm được film" });
            return (wordFirstOfFilm.id, -2, 1.0, errors);
        }


        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_WordFilmServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.WordFilm.Select(x => new
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_WordFilmServiceModel model)
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

            var data = new WordFilm();
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
                createdBy = _currentUserService.userId,
                createdDate = DateTime.Now
            };
            _db.WordFilm.Add(data);
            await _db.SaveChangesAsync();
            return (data, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> AddFeedBackWord(int id, FeedBackaboutWord model)
        {
            var errors = new List<ErrorModel>();
            var data = _db.WordFilm.FirstOrDefault(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "AddFeedBackWord", value = "lỗi ko nhận được id của từ" });
                return (null, errors);
            }
            if (data.feedBackaboutWord == null)
            {
                data.feedBackaboutWord = new List<FeedBackaboutWord>();
            }
            data.feedBackaboutWord.Add(new FeedBackaboutWord
            {
                typeWord = model.typeWord,
                contentFeedBackaboutWord = model.contentFeedBackaboutWord,
                createdBy = _currentUserService.userId,
                createdDate = DateTime.UtcNow,
                status = StatusFeedbackEnum.Show
            });
            _db.WordFilm.Update(data);
            await _db.SaveChangesAsync();
            return (data, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_WordFilmServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.WordFilm.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.WordFilm.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.dataDb.modifiedBy = _currentUserService.userId;
            update.dataDb.modifiedDate = DateTime.Now;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_WordFilmServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.WordFilm.FirstOrDefaultAsync(x => x.id == model.id);
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

            errors.Add(new ErrorModel { key = "", value = "WordFilm delete fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_WordFilmServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.WordFilm.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_WordFilmServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.WordFilm.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }
    }
}
