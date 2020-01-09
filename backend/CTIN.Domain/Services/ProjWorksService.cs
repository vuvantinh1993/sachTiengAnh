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
    public interface IProjWorksService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjWorksServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjWorksServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjWorksServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjWorksServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjWorksServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ProjWorksServiceModel model);
    }

    public class ProjWorksService : IProjWorksService
    {
        private readonly ILogger<ProjWorksService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly ITimeSheetService _timeSheetService;
        public readonly ITimeSheetDetailService _timeSheetDetailService;

        public ProjWorksService(ILogger<ProjWorksService> log, NATemplateContext db, ICurrentUserService currentUserService, ITimeSheetService timeSheetService, ITimeSheetDetailService timeSheetDetailService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _timeSheetService = timeSheetService;
            _timeSheetDetailService = timeSheetDetailService;
        }

        public int statusDelete { get => (int)StatusDb.Delete; }
        public IQueryable<ProjWorks> _query
        {
            get => _db.ProjWorks.Include(x => x.target).Include(x => x.projGeneral).Include(x => x.status).AsQueryable();
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjWorksServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _query.GroupBy(x => x.projGeneralId).Select(x => new { 
                id = x.Key,
                projName = x.Select(y => y.projGeneral.projName).FirstOrDefault(),
                beginDate = x.Select(y => y.projGeneral.beginDate).FirstOrDefault(),
                endDate = x.Select(y => y.projGeneral.endDate).FirstOrDefault(),
                projWork = x });
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.projWork.Select(y => y.delete).FirstOrDefault() != statusDelete);
            }
            else
            {
                query = query.Where(x => x.projWork.Select(y => y.delete).FirstOrDefault() != statusDelete);
            }
            //var query = _query;
            //if (model.where != null)
            //{
            //    query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            //}
            //else
            //{
            //    query = query.Where(x => x.delete != statusDelete);
            //}
            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjWorksServiceModel model)
        {
            var errors = new List<ErrorModel>();

            // Validate
            var name = _db.ProjWorks.Where(x => x.workName == model.workName && x.projGeneralId == model.projGeneralId).Count();
            if (name > 0)
            {
                errors.Add(new ErrorModel { key = "workName", value = "Tên công việc đã tồn tại" });
            }
            else
            {
                var beginDate = _db.ProjGeneral.FirstOrDefault(x => x.id == model.projGeneralId).beginDate;
                var endDate = _db.ProjGeneral.FirstOrDefault(x => x.id == model.projGeneralId).endDate;
                if (model.beginDate < beginDate || model.beginDate > endDate)
                {
                    errors.Add(new ErrorModel { key = "beginDate", value = "Ngày bắt đầu phải nằm trong khoảng thời gian của dự án: " + beginDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy") });
                }
                if (model.endDate < beginDate || model.endDate > endDate)
                {
                    errors.Add(new ErrorModel { key = "endDate", value = "Ngày kết thúc phải nằm trong khoảng thời gian của dự án: " + beginDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy") });
                }
                if (errors.Count() == 0)
                {
                    _db.ProjWorks.Add(model);
                    // Add TimeSheet
                    var newTimeSheet = new Add_TimeSheetServiceModel();
                    newTimeSheet.projworkId = model.id;
                    newTimeSheet.dateNumber = (model.endDate - model.beginDate).Days + 1;
                    newTimeSheet.startDay = model.beginDate;
                    newTimeSheet.endDate = model.endDate;
                    var rs = await _timeSheetService.Add(newTimeSheet);

                    // Add timesheetDetail
                    var newTimeSheetDetail = new Add_TimeSheetDetailServiceModel
                    {
                        startDate = newTimeSheet.startDay,
                        endDate = newTimeSheet.endDate,
                        timeSheetId = rs.data.id,
                        dataDb = new DataDbJson
                        {
                            createdBy = Int32.Parse(_currentUserService.userId)
                        }
                    };
                    await _timeSheetDetailService.Add(newTimeSheetDetail);
                    await _db.SaveChangesAsync();
                }
            }
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjWorksServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ProjWorks.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var name = _db.ProjWorks.Where(x => x.id != model.id && x.workName == model.workName && x.projGeneralId == model.projGeneralId).Count();
            if (name > 0)
            {
                errors.Add(new ErrorModel { key = "workName", value = "Tên công việc đã tồn tại" });
            }
            else
            {
                var beginDate = _db.ProjGeneral.FirstOrDefault(x => x.id == model.projGeneralId).beginDate;
                var endDate = _db.ProjGeneral.FirstOrDefault(x => x.id == model.projGeneralId).endDate;
                if (model.beginDate < beginDate || model.beginDate > endDate)
                {
                    errors.Add(new ErrorModel { key = "beginDate", value = "Ngày bắt đầu phải nằm trong khoảng thời gian của dự án: " + beginDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy") });
                }
                if (model.endDate < beginDate || model.endDate > endDate)
                {
                    errors.Add(new ErrorModel { key = "endDate", value = "Ngày kết thúc phải nằm trong khoảng thời gian của dự án: " + beginDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy") });
                }
                if (errors.Count() == 0)
                {
                    var update = data.Patch(model);
                    update.createdBy = data.createdBy;
                    update.createdDate = data.createdDate;
                    _db.Entry(data).CurrentValues.SetValues(update);
                    if (await _db.SaveChangesAsync() > 0)
                    {
                        return (update, errors);
                    }
                    errors.Add(new ErrorModel { key = "fail", value = "Lỗi hệ thống! lưu thất bại" });
                }
            }
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ProjWorks.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjWorksServiceModel model)
        {
            var errors = new List<ErrorModel>();
            using (var transaction = TransectionScopeExtension.Create())
            {
                try
                {
                    var data = await _db.ProjWorks.FirstOrDefaultAsync(x => x.id == model.id);
                    var listTimeSheetId = await _db.TimeSheet.Where(x => x.projworkId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    if (data == null)
                    {
                        errors.Add(new ErrorModel { key = "", value = "share.notExist" });
                    }

                    var checkerr = false;
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(new { delete = statusDelete }));


                    if (listTimeSheetId != null)
                    {
                        foreach (var id in listTimeSheetId)
                        {
                            var hasError = await _timeSheetService.Delete(new Delete_TimeSheetServiceModel { id = id });
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
                            errors.Add(new ErrorModel { key = "", value = "ProjWorks delete fail" });
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjWorksServiceModel model)
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ProjWorksServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.ProjWorks.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            }
            else
            {
                query = query.Where(x => x.delete != statusDelete);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
