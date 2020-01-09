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
    public interface IRevenuesService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_RevenuesServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_RevenuesServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_RevenuesServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_RevenuesServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_RevenuesServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_RevenuesServiceModel model);
    }

    public class RevenuesService : IRevenuesService
    {
        private readonly ILogger<RevenuesService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public RevenuesService(ILogger<RevenuesService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_RevenuesServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (byte)StatusDb.Nomal;
            var statusHide = (byte)StatusDb.Hide;
            var query = (from a in _db.Revenues
                         join c in _db.Contracts on DbFunction.JsonValue(a.data, "$.contractId") equals c.id into Contracts
                         from Contract in Contracts.DefaultIfEmpty()
                         join p in _db.ProjGeneral on DbFunction.JsonValue(a.data, "$.projectId") equals p.id into Projects
                         from Project in Projects.DefaultIfEmpty()
                         join pmt in _db.PaymentType on DbFunction.JsonValue(a.data, "$.paymentType") equals pmt.id into PaymentTypes
                         from PaymentType in PaymentTypes.DefaultIfEmpty()
                         join e in _db.ExpensesItem on DbFunction.JsonValue(a.data, "$.expItenId") equals e.id into ExpensesItems
                         from ExpensesIte in ExpensesItems.DefaultIfEmpty()
                         join pn in _db.Partner on DbFunction.JsonValue(a.data, "$.partId") equals pn.id into Partners
                         from Partner in Partners.DefaultIfEmpty()

                         select new
                         {
                             a.id,
                             a.data,
                             a.dataDb,
                             a.vouchersNumber,
                             contract = Contract,
                             project = Project,
                             paymentType = PaymentType,
                             expItem = ExpensesIte,
                             partner = Partner
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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_RevenuesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var voucher = _db.Revenues.Where(x => x.vouchersNumber == model.vouchersNumber).Count();

            if (voucher > 0)
            {
                errors.Add(new ErrorModel { key = "vouchersNumber", value = "Số chứng từ đã tồn tại" });
            }
            else
            {
                var compareName = _db.Revenues.Where(x => (int)DbFunction.JsonValue(x.data, "$.projectId") == model.data.projectId //&& (int)DbFunction.JsonValue(x.data, "$.expItenId") == model.data.expItenId 
                && (string)DbFunction.JsonValue(x.data, "$.content") == model.data.content).Count();
                if (compareName > 0)
                {
                    errors.Add(new ErrorModel { key = "content", value = "Nội dung đã tồn tại" });
                }
                else
                {
                    _db.Revenues.Add(model);
                    await _db.SaveChangesAsync();
                }
            }
            return (model, errors);

        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_RevenuesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Revenues.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "fail", value = "id không tồn tại" });
            }
            var voucher = _db.Revenues.Where(x => x.id != model.id && x.vouchersNumber == model.vouchersNumber).Count();
            if (voucher > 0)
            {
                errors.Add(new ErrorModel { key = "vouchersNumber", value = "Số chứng từ đã tồn tại" });
            }
            else
            {
                var compareName = _db.Revenues.Where(x => x.id != model.id && x.vouchersNumber == model.vouchersNumber
                           && (int)DbFunction.JsonValue(x.data, "$.projectId") == model.data.projectId
                           && (string)DbFunction.JsonValue(x.data, "$.content") == model.data.content).Count();
                if (compareName > 0)
                {
                    errors.Add(new ErrorModel { key = "content", value = "Nội dung đã tồn tại" });
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
            var data = await _db.Revenues.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_RevenuesServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var data = await _db.Revenues.FirstOrDefaultAsync(x => x.id == model.id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_RevenuesServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.Revenues.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_RevenuesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.Revenues.AsQueryable();

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

