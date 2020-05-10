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

        Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, double speedVideo, Updatepoint_UserLeanningServiceModel model);
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

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_UserLeanningServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.UserLeanning.AsQueryable();

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
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.UserLeanning
                .Where(x => (int)DbFunction.JsonValue(x.dataDb, "$.status") != 3)
                .Select(x => new
                {
                    x.dataDb,
                    x.id,
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

        /// <summary>
        /// update từ đã học vào cột filmlearning
        /// </summary>
        /// <param name="idfilm">là id phim đang học</param>
        /// <param name="sttWord">là sst của từ đã học thuộc</param>
        /// <param name="totalSentenceRight">Tổng số từ làm đúng trong lần học đó</param>
        /// <returns></returns>
        public async Task<(dynamic data, List<ErrorModel> errors)> updateWordlened(int idfilm, int sttWord, int totalSentenceRight, double speedVideo, Updatepoint_UserLeanningServiceModel model)
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
            var update = data.JsonToString().JsonToObject<UserLeanning>();


            //đây là từ học lại
            if (sttWord == -3)
            {
                OneWordUpate_UserLeanningServiceModel tuso1 = new OneWordUpate_UserLeanningServiceModel();
                tuso1.stt = model.stt1;
                tuso1.check = model.check1;
                tuso1.classic = model.classic1;
                var user1 = xulycactuhoclai(data, tuso1, idfilm, speedVideo);
                if (user1.errors.Count() != 0)
                {
                    errors = user1.errors;
                    errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 1 không thành công" });
                    return (null, errors);
                }
                if (model.stt2 != null)
                {
                    OneWordUpate_UserLeanningServiceModel tuso2 = new OneWordUpate_UserLeanningServiceModel();
                    tuso2.stt = model.stt2;
                    tuso2.check = model.check2;
                    tuso2.classic = model.classic2;
                    var user2 = xulycactuhoclai(user1.userdata, tuso2, idfilm, speedVideo);
                    if (user2.errors.Count() != 0)
                    {
                        errors = user1.errors;
                        errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 2 không thành công 4" });
                        return (null, errors);
                    }
                    if (model.stt3 != null)
                    {
                        OneWordUpate_UserLeanningServiceModel tuso3 = new OneWordUpate_UserLeanningServiceModel();
                        tuso3.stt = model.stt3;
                        tuso3.check = model.check3;
                        tuso3.classic = model.classic3;
                        var user3 = xulycactuhoclai(user2.userdata, tuso3, idfilm, speedVideo);
                        if (user3.errors.Count() != 0)
                        {
                            errors = user2.errors;
                            errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 3 không thành công 4" });
                            return (null, errors);
                        }
                        if (model.stt4 != null)
                        {
                            OneWordUpate_UserLeanningServiceModel tuso4 = new OneWordUpate_UserLeanningServiceModel();
                            tuso4.stt = model.stt4;
                            tuso4.check = model.check4;
                            tuso4.classic = model.classic4;
                            var user4 = xulycactuhoclai(user2.userdata, tuso4, idfilm, speedVideo);
                            if (user4.errors.Count() != 0)
                            {
                                errors = user3.errors;
                                errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 4 không thành công 4" });
                                return (null, errors);
                            }
                            // update usser vaf coongj ddieemr cho USER4
                            var totalPointRight = totalSentenceRight * film.pointword;
                            user4.userdata.point += totalPointRight;
                            _db.Entry(data).CurrentValues.SetValues(user4.userdata);
                            if (await _db.SaveChangesAsync() > 0)
                            {
                                return (new { totalSentenceRight, totalPointRight }, errors);
                            }
                            errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 4 không thành công 1" });
                        }
                        else
                        {
                            // update usser vaf coongj ddieemr cho USER3
                            var totalPointRight = totalSentenceRight * film.pointword;
                            user3.userdata.point += totalPointRight;
                            _db.Entry(data).CurrentValues.SetValues(user3.userdata);
                            if (await _db.SaveChangesAsync() > 0)
                            {
                                return (new { totalSentenceRight, totalPointRight }, errors);
                            }
                            errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 3 không thành công 1" });
                            return (null, errors);
                        }
                    }
                    else
                    {
                        // update usser vaf coongj ddieemr cho USER2
                        var totalPointRight = totalSentenceRight * film.pointword;
                        user2.userdata.point += totalPointRight;
                        _db.Entry(data).CurrentValues.SetValues(user2.userdata);
                        if (await _db.SaveChangesAsync() > 0)
                        {
                            return (new { totalSentenceRight, totalPointRight }, errors);
                        }
                        errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 2 không thành công 1" });
                        return (null, errors);
                    }
                }
                else
                {
                    // update usser vaf coongj ddieemr cho USER1
                    var totalPointRight = totalSentenceRight * film.pointword;
                    user1.userdata.point += totalPointRight;
                    _db.Entry(data).CurrentValues.SetValues(user1);
                    if (await _db.SaveChangesAsync() > 0)
                    {
                        return (new { totalSentenceRight, totalPointRight }, errors);
                    }
                    errors.Add(new ErrorModel { key = "updateWordlened", value = "update từ học lại số 1 không thành công 2" });
                    return (null, errors);
                }
            }
            else if (sttWord > -2) //đây là từ học mới
            {
                var filmleanning = new List<userfilmleanningDataJson>();
                foreach (var item in data.filmleanning)
                {
                    item.speedVideo = speedVideo;
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

            errors.Add(new ErrorModel { key = "updateWordlened", value = "Không tồn tại  từ update" });
            return (null, errors);

        }

        public (UserLeanning userdata, List<ErrorModel> errors) xulycactuhoclai(UserLeanning data, OneWordUpate_UserLeanningServiceModel model, int idfilm, double speedVideo)
        {
            var errors = new List<ErrorModel>();
            var userJson1 = data.JsonToString().JsonToObject<UserLeanning>();
            if (model.classic == 2)
            {
                // nó đang ở cột thứ 2 filmforget ta cần kiểm tra xem đưa về leanning hay fisnish
                if (userJson1.filmforgeted != null)
                {
                    foreach (userfilmleanningDataJson filma in userJson1.filmforgeted)
                    {
                        var filmJson1 = filma.JsonToString().JsonToObject<userfilmleanningDataJson>();
                        filmJson1.speedVideo = speedVideo;
                        List<wordleanedDataJson> listWord1 = new List<wordleanedDataJson>();
                        List<wordleanedDataJson> listWord2 = new List<wordleanedDataJson>();
                        if (filma.filmid == idfilm)
                        {
                            var findWord1 = filma.wordleaned.Find(x => x.stt == model.stt);
                            if (findWord1 != null)
                            {
                                if (findWord1.check == 1 || findWord1.check == 2)
                                {
                                    //từ này vừa mới học lần 2 và lần 3 chuyển về cột leanning
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    iteamWordLeaned.stt = findWord1.stt;
                                    iteamWordLeaned.time = DateTime.UtcNow;
                                    iteamWordLeaned.isforget = 0;
                                    iteamWordLeaned.check = findWord1.check + 1;
                                    iteamWordLeaned.classic = 1; // chuyển về cột leanning

                                    foreach (var a in userJson1.filmleanning)
                                    {
                                        if (a.filmid == idfilm)
                                        {
                                            a.wordleaned.Add(iteamWordLeaned);
                                        }
                                    }

                                    filma.wordleaned.Remove(findWord1);
                                }
                                else
                                {
                                    //từ này vừa mới học lần 4 fisnish
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    iteamWordLeaned.stt = findWord1.stt;
                                    iteamWordLeaned.time = DateTime.UtcNow;
                                    iteamWordLeaned.isforget = 0;
                                    iteamWordLeaned.check = findWord1.check + 1;
                                    iteamWordLeaned.classic = 3; // chuyển về cột fisnish
                                    foreach (var a in userJson1.filmfinish)
                                    {
                                        if (a.filmid == idfilm)
                                        {
                                            a.wordleaned.Add(iteamWordLeaned);
                                        }
                                    }
                                    filma.wordleaned.Remove(findWord1);
                                }
                            }
                            else
                            {
                                errors.Add(new ErrorModel { key = "updateWordlened", value = "Từ vừa học đã lưu vào CSDL rồi" });
                                return (null, errors);
                            }
                        }
                    }
                }
            }
            else if (model.classic == 3)
            {
                // nó đang ở cột thứ 3 filmpunish ta cần kiểm tra xem đưa về leanning hay fisnish
                if (userJson1.filmpunishing != null)
                {
                    foreach (userfilmleanningDataJson filma in userJson1.filmpunishing)
                    {
                        var filmJson1 = filma.JsonToString().JsonToObject<userfilmleanningDataJson>();
                        filmJson1.speedVideo = speedVideo;
                        List<wordleanedDataJson> listWord1 = new List<wordleanedDataJson>();
                        List<wordleanedDataJson> listWord2 = new List<wordleanedDataJson>();
                        if (filma.filmid == idfilm)
                        {
                            var findWord1 = filma.wordleaned.Find(x => x.stt == model.stt);
                            if (findWord1 != null)
                            {
                                if (findWord1.check == 1 || findWord1.check == 2)
                                {
                                    //từ này vừa mới học lần 2 và lần 3 chuyển về cột leanning
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    iteamWordLeaned.stt = findWord1.stt;
                                    iteamWordLeaned.time = DateTime.UtcNow;
                                    iteamWordLeaned.isforget = 0;
                                    iteamWordLeaned.check = findWord1.check + 1;
                                    iteamWordLeaned.classic = 1; // chuyển về cột leanning

                                    foreach (var a in userJson1.filmleanning)
                                    {
                                        if (a.filmid == idfilm)
                                        {
                                            a.wordleaned.Add(iteamWordLeaned);
                                        }
                                    }

                                    filma.wordleaned.Remove(findWord1);
                                }
                                else
                                {
                                    //từ này vừa mới học lần 4 fisnish
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    iteamWordLeaned.stt = findWord1.stt;
                                    iteamWordLeaned.time = DateTime.UtcNow;
                                    iteamWordLeaned.isforget = 0;
                                    iteamWordLeaned.check = findWord1.check + 1;
                                    iteamWordLeaned.classic = 3; // chuyển về cột fisnish
                                    foreach (var a in userJson1.filmfinish)
                                    {
                                        if (a.filmid == idfilm)
                                        {
                                            a.wordleaned.Add(iteamWordLeaned);
                                        }
                                    }
                                    filma.wordleaned.Remove(findWord1);
                                }

                            }
                            else
                            {
                                errors.Add(new ErrorModel { key = "updateWordlened", value = "Từ vừa học đã lưu vào CSDL rồi" });
                                return (null, errors);
                            }
                        }
                    }

                }
            }
            else
            {
                // nó đang ở cột thứ 4 filmfinish không cần chuyển cột
                if (userJson1.filmfinish != null)
                {
                    foreach (userfilmleanningDataJson filma in userJson1.filmfinish)
                    {
                        var filmJson1 = filma.JsonToString().JsonToObject<userfilmleanningDataJson>();
                        filmJson1.speedVideo = speedVideo;
                        List<wordleanedDataJson> listWord1 = new List<wordleanedDataJson>();
                        List<wordleanedDataJson> listWord2 = new List<wordleanedDataJson>();
                        if (filma.filmid == idfilm)
                        {
                            var findWord1 = filma.wordleaned.Find(x => x.stt == model.stt);
                            if (findWord1 != null)
                            {
                                if (findWord1.check >= 4)
                                {
                                    //từ này vừa mới học lần 4 và lần 3 giữ nguyên ở cột fisnnish
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    iteamWordLeaned.stt = findWord1.stt;
                                    iteamWordLeaned.time = DateTime.UtcNow;
                                    iteamWordLeaned.isforget = 0;
                                    iteamWordLeaned.check = findWord1.check + 1;
                                    iteamWordLeaned.classic = 3; // chuyển về cột leanning

                                    filma.wordleaned.Remove(findWord1);
                                    filma.wordleaned.Add(iteamWordLeaned);
                                }
                            }
                            else
                            {
                                errors.Add(new ErrorModel { key = "updateWordlened", value = "Từ vừa học đã lưu vào CSDL rồi" });
                                return (null, errors);
                            }
                        }
                    }

                }
            }
            return (userJson1, errors); ;
        }

    }
}
