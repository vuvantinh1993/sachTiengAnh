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
    public interface ITempService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_TemplateServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_TemplateServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(Guid id, Edit_TemplateServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(Guid id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_TemplateServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_TemplateServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_TemplateServiceModel model);
    }

    public class TempService : ITempService
    {
        private readonly ILogger<TempService> _log;
        private readonly NATemplateContext _db;
        public TempService(ILogger<TempService> log, NATemplateContext db)
        {
            _log = log; _db = db;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Template.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            //get db by name
            //if neu toan tai

            _db.Template.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(Guid id, Edit_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Template.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(Guid id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Template.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Template.FirstOrDefaultAsync(x => x.id == model.id);
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

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Template.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_TemplateServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Template.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
