using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
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
    public interface ICollateCostsService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_CollateCostsServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_CollateCostsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_CollateCostsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_CollateCostsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_CollateCostsServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_CollateCostsServiceModel model);
    }

    public class CollateCostsService : ICollateCostsService
    {
        private readonly ILogger<CollateCostsService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public CollateCostsService(ILogger<CollateCostsService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_CollateCostsServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (byte)StatusDb.Nomal;
            var statusHide = (byte)StatusDb.Hide;
            var query = _db.CollateCosts.AsQueryable();

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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_CollateCostsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var voucher = _db.CollateCosts.Where(x => x.vouchersNumber == model.vouchersNumber).Count();
            if (voucher > 0)
            {
                errors.Add(new ErrorModel { key = "vouchersNumber", value = "Số chứng từ đã tồn tại" });
            }
            else
            {
                var compareName = _db.CollateCosts.Where(x => (int)DbFunction.JsonValue(x.data, "$.projectId") == model.data.projectId && //(int)DbFunction.JsonValue(x.data, "$.expItenId") == model.data.expItenId &&
                (string)DbFunction.JsonValue(x.data, "$.content") == model.data.content).Count();
                if (compareName > 0)
                {
                    errors.Add(new ErrorModel { key = "content", value = "Tên chi phí đã tồn tại" });
                }
                else
                {
                    _db.CollateCosts.Add(model);
                    await _db.SaveChangesAsync();
                }
            }
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_CollateCostsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.CollateCosts.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "fail", value = "Số chứng từ không tồn tại" });
            }
            var voucher = _db.CollateCosts.Where(x => x.id != model.id && x.vouchersNumber == model.vouchersNumber).Count();
            if (voucher > 0)
            {
                errors.Add(new ErrorModel { key = "vouchersNumber", value = "Số chứng từ đã tồn tại" });
            }
            else
            {
                var compareName = _db.CollateCosts.Where(x => x.id != model.id && x.vouchersNumber == model.vouchersNumber
                && (int)DbFunction.JsonValue(x.data, "$.projectId") == model.data.projectId //&& (int)DbFunction.JsonValue(x.data, "$.expItenId") == model.data.expItenId 
            && (string)DbFunction.JsonValue(x.data, "$.content") == model.data.content).Count();
                if (compareName > 0)
                {
                    errors.Add(new ErrorModel { key = "content", value = "Tên chi phí đã tồn tại" });
                }
                else
                {
                    var update = data.Patch(model);
                    _db.Entry(data).CurrentValues.SetValues(update);
                    if (await _db.SaveChangesAsync() > 0)
                    {
                        return (update, errors);
                    }
                    errors.Add(new ErrorModel { key = "fail", value = "Lỗi hệ thống! Cập nhật thất bại" });
                }
            }
            return (null, errors);

        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.CollateCosts.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "fail", value = "Số chứng từ không tồn tại" });
            }
            var update = data.Patch(model);
            update.dataDb.modifiedBy = Int32.Parse(_currentUserService.userId);
            update.dataDb.modifiedDate = DateTime.Now;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "fail", value = "Lỗi hệ thống! Cập nhật thất bại" });
            return (null, errors);

        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_CollateCostsServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var data = await _db.CollateCosts.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "fail", value = "Số chứng từ không tồn tại" });
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

            errors.Add(new ErrorModel { key = "fail", value = "Lỗi hệ thống! Xóa dữ liệu thất bại" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_CollateCostsServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.CollateCosts.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_CollateCostsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.CollateCosts.AsQueryable();

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

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}

