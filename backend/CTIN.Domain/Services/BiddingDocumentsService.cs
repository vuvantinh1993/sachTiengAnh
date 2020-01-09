using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Bases;
using CTIN.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CTIN.Domain.Services
{
    public interface IBiddingDocumentsService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_BiddingDocumentsServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_BiddingDocumentsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_BiddingDocumentsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_BiddingDocumentsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_BiddingDocumentsServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_BiddingDocumentsServiceModel model);
    }

    public class BiddingDocumentsService : IBiddingDocumentsService
    {
        private readonly ILogger<BiddingDocumentsService> _log;
        private readonly NATemplateContext _db;
        private readonly ICurrentUserService _currentUserService;
        private readonly IActtachmentsService _acttachmentsService;

        public BiddingDocumentsService(
            ILogger<BiddingDocumentsService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            IActtachmentsService acttachmentsService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _acttachmentsService = acttachmentsService;
        }

        public IQueryable<BiddingDocuments> _query
        {
            get => _db.BiddingDocuments
                .Include(x => x.proj)
                .Include(x => x.packageBids)
                .AsQueryable();
        }
        public int statusDelete { get => (int)StatusDb.Delete; }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_BiddingDocumentsServiceModel model)
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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_BiddingDocumentsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.BiddingDocuments.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_BiddingDocumentsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.BiddingDocuments.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.BiddingDocuments.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_BiddingDocumentsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.BiddingDocuments.Where(x => x.delete != statusDelete).FirstOrDefaultAsync(x => x.id == model.id);
            var listFileId = await _db.Acttachments.Where(x => x.fileData.biddingDocument == model.id).Where(x => x.dataDb.status != statusDelete).Select(x => x.id).ToArrayAsync();

            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }

            using (var transaction = TransectionScopeExtension.Create())
            {
                try
                {
                    var checkerr = false;
                    // update value delete
                    var update = new { delete = statusDelete };
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(update));

                    if (listFileId != null)
                    {
                        foreach (var id in listFileId)
                        {
                            var hasError = await _acttachmentsService.Delete(new Delete_ActtachmentsServiceModel { id = id });
                            checkerr = hasError.errors.Count() > 0 ? true : false;
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (checkerr == true)
                    {
                        if (await _db.SaveChangesAsync() < 0)
                        {
                            errors.Add(new ErrorModel { key = "", value = "BiddingDocuments delete fail" });
                        }
                        return (null, errors);
                    }
                    else
                    {
                        await _db.SaveChangesAsync();
                        transaction.Complete();
                        return (data, errors);
                    }
                }
                catch (Exception e)
                {
                    errors.Add(new ErrorModel { key = "", value = e.Message });
                    return (null, errors);
                }
            }
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_BiddingDocumentsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _query;

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_BiddingDocumentsServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.BiddingDocuments.Include(x => x.proj).Include(x => x.packageBids).AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
