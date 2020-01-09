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
   public interface IProjProfileDetailService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjProfileDetailServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjProfileDetailServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjProfileDetailServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjProfileDetailServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjProfileDetailServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ProjProfileDetailServiceModel model);
    }
    public class ProjProfileDetailService : IProjProfileDetailService
    {
        private readonly ILogger<ProjProfileDetailService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public ProjProfileDetailService(ILogger<ProjProfileDetailService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjProfileDetailServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.ProjProfileDetail.AsQueryable();

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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjProfileDetailServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.ProjProfileDetail.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjProfileDetailServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ProjProfileDetail.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.ProjProfileDetail.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjProfileDetailServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var dataDeleted = new List<ProjProfileDetail>();
            var deletedChilds = new List<ProjProfileDetail>();
            var data = await _db.ProjProfileDetail.FirstOrDefaultAsync(x => x.id == model.id);
            var dataChilds = await _db.ProjProfileDetail.Where(x => x.data.idProjProfile == model.id).ToListAsync();
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
                    var deletedChild = await Delete(new Delete_ProjProfileDetailServiceModel
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjProfileDetailServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ProjProfileDetail.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ProjProfileDetailServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ProjProfileDetail.AsQueryable();

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
