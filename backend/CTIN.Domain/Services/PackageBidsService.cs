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
    public interface IPackageBidsService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_PackageBidsServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_PackageBidsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_PackageBidsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_PackageBidsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_PackageBidsServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_PackageBidsServiceModel model);
    }

    public class PackageBidsService : IPackageBidsService
    {
        private readonly ILogger<PackageBidsService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly IBiddingDocumentsService _biddingDocumentsService;
        public readonly IContractsService _contractsService;
        private readonly IActtachmentsService _acttachmentsService;

        public PackageBidsService(
            ILogger<PackageBidsService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            IBiddingDocumentsService biddingDocumentsService,
            IContractsService contractsService,
            IActtachmentsService acttachmentsService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _biddingDocumentsService = biddingDocumentsService;
            _contractsService = contractsService;
            _acttachmentsService = acttachmentsService;
        }

        public int statusDelete { get => (int)StatusDb.Delete; }
        public IQueryable<PackageBids> _query
        {
            get => _db.PackageBids
                .Include(x => x.contractor)
                .Include(x => x.proj)
                .Include(x => x.status)
                .Include(x => x.bid)
                .Include(x => x.bidModel)
                .Include(x => x.part)
                .AsQueryable();
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_PackageBidsServiceModel model)
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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_PackageBidsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.PackageBids.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_PackageBidsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.PackageBids.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.PackageBids.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_PackageBidsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            using (var transaction = TransectionScopeExtension.Create())
            {
                try
                {
                    var data = await _db.PackageBids.FirstOrDefaultAsync(x => x.id == model.id);
                    var listBidDocID = await _db.BiddingDocuments.Where(x => x.packageBidsId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listContractId = await _db.Contracts.Where(x => x.packageBidsId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listFileId = await _db.Acttachments.Where(x => x.fileData.packageBids == model.id).Where(x => x.dataDb.status != statusDelete).Select(x => x.id).ToArrayAsync();

                    if (data == null)
                    {
                        errors.Add(new ErrorModel { key = "", value = "share.notExist" });
                    }

                    var checkerr = false;
                    // update value delete
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(new { delete = statusDelete }));

                    if (listBidDocID != null)
                    {
                        foreach (var id in listBidDocID)
                        {
                            var hasError = await _biddingDocumentsService.Delete(new Delete_BiddingDocumentsServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listContractId != null)
                    {
                        foreach (var id in listContractId)
                        {
                            var hasError = await _contractsService.Delete(new Delete_ContractsServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listFileId != null)
                    {
                        foreach (var id in listFileId)
                        {
                            var hasError = await _acttachmentsService.Delete(new Delete_ActtachmentsServiceModel { id = id });
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
                            errors.Add(new ErrorModel { key = "", value = "Packages delete fail" });
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_PackageBidsServiceModel model)
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_PackageBidsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.PackageBids.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
