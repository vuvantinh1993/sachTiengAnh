using CTIN.Common.Enums;
using CTIN.Common.Extentions;
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
    public interface ILogWorkService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_LogWorkServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_LogWorkServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_LogWorkServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_LogWorkServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_LogWorkServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_LogWorkServiceModel model);
    }

    public class LogWorkService : ILogWorkService
    {
        private readonly ILogger<LogWorkService> _log;
        private readonly NATemplateContext _db;
        public LogWorkService(ILogger<LogWorkService> log, NATemplateContext db)
        {
            _log = log; _db = db;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.LogWork.AsQueryable();
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }
            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.LogWork.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.LogWork.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.LogWork.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.LogWork.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            else
            {
                _db.Remove(data);
            }
            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.LogWork.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_LogWorkServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.LogWork.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
