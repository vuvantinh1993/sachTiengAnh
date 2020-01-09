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
    public interface IPaymentScheduleService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_PaymentScheduleServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_PaymentScheduleServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_PaymentScheduleServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_PaymentScheduleServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_PaymentScheduleServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_PaymentScheduleServiceModel model);
    }

    public class PaymentScheduleService : IPaymentScheduleService
    {
        private readonly ILogger<PaymentScheduleService> _log;
        private readonly NATemplateContext _db;
        private readonly ICurrentUserService _currentUserService;
        private IQueryable<PaymentSchedule> _query;
        private int statusDelete;

        public PaymentScheduleService(ILogger<PaymentScheduleService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _query = _db.PaymentSchedule.AsQueryable();
            statusDelete = (int)StatusDb.Delete;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _query;
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            }
            else
            {
                query = query.Where(x => x.delete != statusDelete);
            }
            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.PaymentSchedule.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.PaymentSchedule.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.createdBy = data.createdBy;
            update.createdDate = data.createdDate;
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
            var data = await _db.PaymentSchedule.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.modifiedDate = DateTime.Now;
            update.modifiedBy = _currentUserService.userId;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.PaymentSchedule.Where(x => x.delete != statusDelete).FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }

            _db.Entry(data).CurrentValues.SetValues(new { delete = statusDelete });
            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "PaymentSchedule delete fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _query;
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            }
            else
            {
                query = query.Where(x => x.delete != statusDelete);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_PaymentScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.PaymentSchedule.AsQueryable();
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            }
            else
            {
                query = query.Where(x => x.delete != statusDelete);
            }
            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
