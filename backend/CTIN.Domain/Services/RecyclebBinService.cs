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
    public interface IRecyclebBinService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_RecyclebBinServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_RecyclebBinServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Restore(Restore_RecyclebBinServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_RecyclebBinServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_RecyclebBinServiceModel model);
    }

    public class RecyclebBinService : IRecyclebBinService
    {
        private readonly ILogger<RecyclebBinService> _log;
        private readonly NATemplateContext _db;
        public RecyclebBinService(ILogger<RecyclebBinService> log, NATemplateContext db)
        {
            _log = log; _db = db;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_RecyclebBinServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.RecyclebBin.AsQueryable();

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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_RecyclebBinServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var data = await _db.RecyclebBin.FirstOrDefaultAsync(x => x.id == model.id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Restore(Restore_RecyclebBinServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.RecyclebBin.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }

            ///tạo transaction để, tắt id tự động tăng rồi retore lại tài liệu (hiện tại đang làm dở)
            //using (var transaction = _db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        switch (data.data.tableName)
            //        {
            //            case "ProjWorks":
            //                var modelProjWorksService = data.data.valData.MapToObject<Add_ProjWorksServiceModel>();
            //                modelProjWorksService.id = null;
            //                _db.ProjWorks.Add(modelProjWorksService);
            //                _db.RecyclebBin.Remove(data);
            //                break;
            //            case "ProjGeneral":
            //                var modelProjGeneralService = data.data.valData.MapToObject<Add_ProjGeneralServiceModel>();
            //                modelProjGeneralService.id = null;
            //                _db.ProjGeneral.Add(modelProjGeneralService);
            //                _db.RecyclebBin.Remove(data);
            //                break;
            //            case "ProjectResources":
            //                var modelProjectResourcesService = data.data.valData.MapToObject<Add_ProjectResourcesServiceModel>();
            //                modelProjectResourcesService.id = null;
            //                _db.ProjectResources.Add(modelProjectResourcesService);
            //                _db.RecyclebBin.Remove(data);
            //                break;
            //            case "Issue":
            //                var modelIssueService = data.data.valData.MapToObject<Add_IssueServiceModel>();
            //                modelIssueService.id = null;
            //                _db.Issue.Add(modelIssueService);
            //                _db.RecyclebBin.Remove(data);
            //                break;
            //        }
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //    }
            //}

            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_RecyclebBinServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var query = _db.RecyclebBin.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_RecyclebBinServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.RecyclebBin.AsQueryable();

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

