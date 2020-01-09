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
    public interface IContractsService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ContractsServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ContractsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ContractsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ContractsServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ContractsServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ContractsServiceModel model);
    }

    public class ContractsService : IContractsService
    {
        private readonly ILogger<ContractsService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        private IHandoverScheduleService _handoverScheduleService;
        private IPaymentScheduleService _paymentScheduleService;
        private IActtachmentsService _acttachmentsService;

        public ContractsService(
            ILogger<ContractsService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            IHandoverScheduleService handoverScheduleService,
            IPaymentScheduleService paymentScheduleService,
            IActtachmentsService acttachmentsService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _handoverScheduleService = handoverScheduleService;
            _paymentScheduleService = paymentScheduleService;
            _acttachmentsService = acttachmentsService;
        }

        public int statusDelete { get => (int)StatusDb.Delete; }
        public IQueryable<Contracts> _query
        {
            get => _db.Contracts
                .Include(x => x.proj)
                .Include(x => x.status)
                .Include(x => x.packageBids)
                .Include(x => x.contractForm)
                .Include(x => x.paymentType)
                .Include(x => x.termsOfPayment)
                .AsQueryable();
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ContractsServiceModel model)
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


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ContractsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.Contracts.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ContractsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Contracts.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.Contracts.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ContractsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Contracts.FirstOrDefaultAsync(x => x.id == model.id);
            var litsHandoveId = await _db.HandoverSchedule.Where(x => x.contractsId == model.id).Where(x => x.delete != 3).Select(x => x.id).ToArrayAsync();
            var litsPaymentId = await _db.PaymentSchedule.Where(x => x.contractId == model.id).Where(x => x.delete != 3).Select(x => x.id).ToArrayAsync();
            var listFileId = await _db.Acttachments.Where(x => x.fileData.contracts == model.id).Where(x => x.dataDb.status != 3).Select(x => x.id).ToArrayAsync();
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
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(new { delete = statusDelete }));

                    if (litsPaymentId != null)
                    {
                        foreach (var id in litsPaymentId)
                        {
                            var hasError = await _paymentScheduleService.Delete(new Delete_PaymentScheduleServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }

                    if (litsHandoveId != null)
                    {
                        foreach (var id in litsHandoveId)
                        {
                            var hasError = await _handoverScheduleService.Delete(new Delete_HandoverScheduleServiceModel { id = id });
                            checkerr = hasError.errors.Count() > 0 ? true : false;
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
                            errors.Add(new ErrorModel { key = "", value = "Contracts delete fail" });
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ContractsServiceModel model)
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ContractsServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.Contracts.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
