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
    public interface IExpensesItemGroupService
    {

        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExpensesItemGroupServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExpensesItemGroupServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExpensesItemGroupServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExpensesItemGroupServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExpensesItemGroupServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ExpensesItemGroupServiceModel model);
    }
    public class ExpensesItemGroupService : IExpensesItemGroupService
    {
        private readonly ILogger<ExpensesItemGroupService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly IExpensesItemService _expensesItemService;

        public ExpensesItemGroupService(ILogger<ExpensesItemGroupService> log, NATemplateContext db, ICurrentUserService currentUserService, IExpensesItemService expensesItemService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _expensesItemService = expensesItemService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExpensesItemGroupServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.ExpensesItemGroup.AsQueryable();

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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExpensesItemGroupServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.ExpensesItemGroup.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExpensesItemGroupServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ExpensesItemGroup.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.ExpensesItemGroup.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExpensesItemGroupServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var data = await _db.ExpensesItemGroup.FirstOrDefaultAsync(x => x.id == model.id);
            var listChildsId = await _db.ExpensesItem.Where(x => x.data.expItemGroup == model.id).Select(x => x.id).ToArrayAsync();

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

            // neu co list item Child thi xoa
            if (listChildsId != null)
            {
                foreach (var id in listChildsId)
                {
                    await _expensesItemService.Delete(new Delete_ExpensesItemServiceModel { id = id });
                }
            }
            try
            {
                await _db.SaveChangesAsync();
                return (data, errors);
            }
            catch
            {
                errors.Add(new ErrorModel { key = "", value = "update fail" });
                return (null, errors);
            }
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExpensesItemGroupServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ExpensesItemGroup.AsQueryable();

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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ExpensesItemGroupServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ExpensesItemGroup.AsQueryable();

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
