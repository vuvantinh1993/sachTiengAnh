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
    public interface IStatusService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_StatusServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_StatusServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_StatusServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_StatusServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_StatusServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_StatusServiceModel model);
    }
    public class StatusService : IStatusService
    {
        private readonly ILogger<StatusService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public StatusService(ILogger<StatusService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }


        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_StatusServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = (from s in _db.Status
                         join c in _db.Status on DbFunction.JsonValue(s.data, "$.statusType") equals c.id into sc
                         from c in sc.DefaultIfEmpty()
                         select new
                         {
                             s.id,
                             s.data,
                             s.dataDb,
                             statusParentName = (string)DbFunction.JsonValue(c.data, "$.statusName")
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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_StatusServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.Status.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_StatusServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Status.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Status.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_StatusServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var dataDeleted = new List<Status>();
            var deletedChilds = new List<Status>();
            var data = await _db.Status.FirstOrDefaultAsync(x => x.id == model.id);
            var dataChilds = await _db.Status.Where(x => x.data.statusType == model.id).ToListAsync();
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

            if (dataChilds != null)
            {
                dataChilds.ForEach(async x =>
                {
                    var deletedChild = await Delete(new Delete_StatusServiceModel
                    {
                        id = x.id,
                        delectationTime = DateTime.Now,
                        delectationBy = Int32.Parse(_currentUserService.userId)
                    });
                    deletedChilds.AddRange(deletedChild.data);
                    errors.AddRange(deletedChild.errors);
                }
                );
                deletedChilds.Add(data);
                dataDeleted = deletedChilds;
            }

            if (await _db.SaveChangesAsync() > 0)
            {
                if (dataDeleted != null)
                {
                    return (dataDeleted, errors);
                }
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_StatusServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = (from s in _db.Status
                         join c in _db.Status on DbFunction.JsonValue(s.data, "$.statusType") equals c.id into Status
                         from status in Status.DefaultIfEmpty()
                         select new
                         {
                             s.id,
                             s.data,
                             s.dataDb,
                             statusName = status.data.statusName,
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_StatusServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = (from s in _db.Status
                         join c in _db.Status on DbFunction.JsonValue(s.data, "$.statusType") equals c.id into Status
                         from status in Status.DefaultIfEmpty()
                         select new
                         {
                             s.id,
                             s.data,
                             s.dataDb,
                             statusName = status.data.statusName,
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

            var result = await query.CountAsync();
            return (result, errors);
        }
    }
}
