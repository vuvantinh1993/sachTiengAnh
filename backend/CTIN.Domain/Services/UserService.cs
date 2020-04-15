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
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_UserServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_UserServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_UserServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_UserServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_UserServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_UserServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, Updatepoint_UserServiceModel model);
    }

    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public UserService(ILogger<UserService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.User.AsQueryable();

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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.User.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.User.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.User.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.User.FirstOrDefaultAsync(x => x.id == model.id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.User
                .Where(x => (int)DbFunction.JsonValue(x.dataDb, "$.status") != 3)
                .Select(x => new
                {
                    x.dataDb,
                    x.id,
                    x.information.name,
                    x.information.image,
                    x.information.address,
                    x.listfrendid,
                    x.point
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
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_UserServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.User.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

        /// <summary>
        /// update từ đã học vào cột filmlearning
        /// </summary>
        /// <param name="idfilm">là id phim đang học</param>
        /// <param name="sttWord">là sst của từ đã học thuộc</param>
        /// <param name="totalSentenceRight">Tổng số từ làm đúng trong lần học đó</param>
        /// <returns></returns>
        public async Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, Updatepoint_UserServiceModel model)
        {

            var userId = 100014;
            var errors = new List<ErrorModel>();
            var data = await _db.User.FirstOrDefaultAsync(x => x.id == userId);
            var film = await _db.Categoryfilm.FirstOrDefaultAsync(x => x.id == idfilm);
            if (data == null || film == null)
            {
                errors.Add(new ErrorModel { key = "updateWordlened", value = "Không tồn tại tài khoản hoặc film" });
                return (null, errors);
            }
            var update = data.JsonToString().JsonToObject<User>();

            //đây là từ học lại
            if (sttWord == -3)
            {
                if (model.classic1 == 1 || model.classic1 == 2)
                {
                    // từ này mới học lần 1(1ngày), lần 2(7nagỳ) chuyển về cột leanning
                }
                else if (model.classic1 == 3)
                {
                    // từ này mới học lần 3(1 tháng) chuyển về cột finish
                }
            }
            else if (sttWord > -2) //đây là từ học mới
            {
                var filmleanning = new List<userfilmleanningDataJson>();
                foreach (var item in data.filmleanning)
                {
                    if (item.filmid == idfilm)
                    {
                        if (sttWord > 0)
                        {
                            var c = new wordleanedDataJson();
                            c.stt = sttWord;
                            c.time = DateTime.UtcNow;
                            c.check = 1;
                            c.classic = 1;
                            c.isforget = 0; // từ chưa quên
                            item.sttWord = sttWord + 1;
                            item.wordleaned.Add(c);
                        }
                        else
                        {
                            item.sttWord = sttWord + 1;
                        }
                    }
                    filmleanning.Add(item);
                }
                update.filmleanning = filmleanning;
                var totalPointRight = totalSentenceRight * film.pointword;
                update.point += totalPointRight;
                _db.Entry(data).CurrentValues.SetValues(update);
                if (await _db.SaveChangesAsync() > 0)
                {
                    return (new { totalSentenceRight, totalPointRight }, errors);
                }
                errors.Add(new ErrorModel { key = "updateWordlened", value = "update lỗi" });
                return (null, errors);

            }

            return (null, errors);

        }

    }
}
