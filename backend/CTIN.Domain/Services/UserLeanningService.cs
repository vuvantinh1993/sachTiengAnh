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
using System.Linq;
using System.Threading.Tasks;

namespace CTIN.Domain.Services
{
    public interface IUserService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_UserLeanningServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_UserLeanningServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_UserLeanningServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_UserLeanningServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_UserLeanningServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_UserLeanningServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, double speedVideo, List<OneWordUpate_UserLeanningServiceModel> wordRelearn);
    }

    public class UserLeanningService : IUserService
    {
        private readonly ILogger<UserLeanningService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public UserLeanningService(ILogger<UserLeanningService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }


        /// <summary>
        /// update từ đã học vào cột filmlearning
        /// </summary>
        /// <param name="idfilm">là id phim đang học</param>
        /// <param name="sttWord">là sst của từ đã học thuộc</param>
        /// <param name="totalSentenceRight">Tổng số từ làm đúng trong lần học đó</param>
        /// <returns></returns>
        public async Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, double speedVideo, List<OneWordUpate_UserLeanningServiceModel> wordRelearn)
        {
            var userId = _currentUserService.userId;
            var errors = new List<ErrorModel>();
            var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.userId == userId);
            var film = await _db.Categoryfilm.FirstOrDefaultAsync(x => x.id == idfilm);
            if (data == null || film == null)
            {
                errors.Add(new ErrorModel { key = "updateWordlened", value = "Không tồn tại tài khoản hoặc film" });
                return (null, errors);
            }
            var dataClone = data.JsonToString().JsonToObject<UserLeanning>();

            if (sttWord == -3)
            {
                //đây là từ học lại
                xulycactuhoclai(dataClone, wordRelearn, idfilm);
            }
            else if (sttWord > -2)
            {
                //đây là từ học Mới
                // Update vào cột listFilmLearned (các từ vừa đã học)
                var filmlearned = dataClone.listFilmLearned.FirstOrDefault(x => x.filmid == idfilm);
                if (filmlearned == null)
                {
                    errors.Add(new ErrorModel { key = "updateWordlened", value = "Không tồn tại film" });
                    return (null, errors);
                }
                else
                {
                    filmlearned.sttWord = sttWord + 1;
                    filmlearned.speedVideo = speedVideo;
                }

                if (sttWord > 0)
                {
                    // Update vào cột wordleanedJson (các từ vừa đã học)
                    var idWord = _db.WordFilm.Where(x => x.stt == sttWord).FirstOrDefault(x => x.categoryfilmid == idfilm).id;
                    var filmnew = new wordleanedJson
                    {
                        idfilm = idfilm,
                        idWord = idWord,
                        time = DateTime.UtcNow,
                        check = 1,
                        classic = ClassicWordEnum.FilmLearnning,
                        isforget = ForgetEnum.NotForget,
                    };
                    if (dataClone.filmLearnning == null)
                    {
                        dataClone.filmLearnning = new List<wordleanedJson>();
                    }
                    dataClone.filmLearnning.Add(filmnew);
                }
            }

            //update điểm số
            var totalPointRight = totalSentenceRight * film.pointword;
            dataClone.point += totalPointRight;
            _db.Entry(data).CurrentValues.SetValues(dataClone);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (new { totalSentenceRight, totalPointRight }, errors);
            }
            errors.Add(new ErrorModel { key = "updateWordlened", value = "update lỗi" });
            return (null, errors);
        }

        public void xulycactuhoclai(UserLeanning dataClone, List<OneWordUpate_UserLeanningServiceModel> wordRelearn, int idfilm)
        {
            wordRelearn.ForEach(x =>
            {
                //Update vào cột wordleanedJson(các từ vừa đã học lại)
                //kiểm tra xem nó chuyển sang trường finish hay new
                switch (x.classic)
                {
                    case ClassicWordEnum.FilmForgeted:
                        // xóa dữ liệu trường FilmForgeted và chuyển về cột
                        dataClone.filmForgeted = dataClone.filmForgeted.Where(y => y.idWord != x.idWord).ToList();
                        if (x.check >= 4)
                        {
                            //chuyển về cột finish
                            //RemoveWordAndAddWord(dataClone.filmForgeted, x, ClassicWordEnum.FilmForgeted, ClassicWordEnum.FilmFinish);
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmFinish,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmFinish == null)
                            {
                                dataClone.filmFinish = new List<wordleanedJson>();
                            }
                            dataClone.filmFinish.Add(filmnew);
                        }
                        else
                        {
                            //chuyển về cột newlearned
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmLearnning,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmLearnning == null)
                            {
                                dataClone.filmLearnning = new List<wordleanedJson>();
                            }
                            dataClone.filmLearnning.Add(filmnew);
                        }
                        break;
                    case ClassicWordEnum.FilmPunishing:
                        // xóa dữ liệu trường FilmPunishing và chuyển về cột
                        dataClone.filmPunishing = dataClone.filmPunishing.Where(y => y.idWord != x.idWord).ToList();
                        if (x.check >= 4)
                        {
                            //chuyển về cột finish
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmFinish,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmFinish == null)
                            {
                                dataClone.filmFinish = new List<wordleanedJson>();
                            }
                            dataClone.filmFinish.Add(filmnew);
                        }
                        else
                        {
                            //chuyển về cột newlearned
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmLearnning,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmLearnning == null)
                            {
                                dataClone.filmLearnning = new List<wordleanedJson>();
                            }
                            dataClone.filmLearnning.Add(filmnew);
                        }
                        break;
                    case ClassicWordEnum.FilmFinishForget:
                        // xóa dữ liệu trường FilmFinishForget và chuyển về cột FilmFinish
                        dataClone.filmFinishForget = dataClone.filmFinishForget.Where(y => y.idWord != x.idWord).ToList();
                        if (x.check >= 4)
                        {
                            //chuyển về cột finish
                            //RemoveWordAndAddWord(dataClone.filmForgeted, x, ClassicWordEnum.FilmForgeted, ClassicWordEnum.FilmFinish);
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmFinish,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmFinish == null)
                            {
                                dataClone.filmFinish = new List<wordleanedJson>();
                            }
                            dataClone.filmFinish.Add(filmnew);
                        }
                        else
                        {
                            // chuyển về cột newlearned
                            // trường hợp này sẽ không thể xảy ra
                            var filmnew = new wordleanedJson
                            {
                                idfilm = idfilm,
                                idWord = x.idWord,
                                time = DateTime.UtcNow,
                                check = x.check + 1,
                                classic = ClassicWordEnum.FilmLearnning,
                                isforget = ForgetEnum.NotForget
                            };
                            if (dataClone.filmLearnning == null)
                            {
                                dataClone.filmLearnning = new List<wordleanedJson>();
                            }
                            dataClone.filmLearnning.Add(filmnew);
                        }
                        break;
                    default:
                        break;
                }
            });
        }


        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.UserLeanning.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.UserLeanning.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.UserLeanning.FirstOrDefaultAsync(x => x.id == model.id);
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

            errors.Add(new ErrorModel { key = "", value = "User delete fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.UserLeanning
                .Select(x => new
                {
                    x.id,
                    x.point
                }).AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.UserLeanning.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }
    }
}
