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

    public interface IModeBiddingService
    {

        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ModeBiddingServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ModeBiddingServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ModeBiddingServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ModeBiddingServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ModeBiddingServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ModeBiddingServiceModel model);
    }
    public class ModeBiddingService : IModeBiddingService
    {
        private readonly ILogger<ModeBiddingService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public ModeBiddingService(ILogger<ModeBiddingService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }


        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ModeBiddingServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var query = _db.ModeBidding.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);                
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ModeBiddingServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.ModeBidding.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ModeBiddingServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ModeBidding.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.ModeBidding.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.modifyby = _currentUserService.userId;
            update.modifydate = DateTime.Now;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);

        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ModeBiddingServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var data = await _db.ModeBidding.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }           
            _db.ModeBidding.Remove(data);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ModeBiddingServiceModel model)
        {

            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ModeBidding.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);               
            }           

            var result = await query.FirstOrDefaultAsync();
            return (result, errors);

        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ModeBiddingServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.ModeBidding.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);              
            }            

            var result = await query.CountAsync();
            return (result, errors);
        }
    }
}
