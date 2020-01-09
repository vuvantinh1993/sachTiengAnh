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
    public interface IProjGeneralService
    {
        /// <summary>
        /// Lấy dữ liệu Bảng ProjGeneral - Thông tin chung dự án
        /// </summary>
        /// <param name="model">
        ///     Model là biểu thức điều kiện Where truyền lên
        ///     Kiểm tra model truyền lên nếu có where thì query sẽ WhereLoopback
        ///     Query sẽ tiếp where theo OrderBy của client đưa lên, nếu client không đưa lên sẽ lấy giá trị mặc định cấu hình tại WebApi-Model
        ///     query sẽ tiếp where theo paging dữ liệu trả về là page(thông tin trang) và data(dữ liệu của trang cần lấy) 
        /// </param>
        /// <returns>
        ///     Trả về data gồm các Object (projGeneral, partnerGroup, projectGroup,target, managementForms, invests, bidding, productServices, status, projectType)
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về paging (totalPage, count, order[{\"projGeneral.id\": false}] , page, sizePage)
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjGeneralServiceModel model);

        /// <summary>
        /// Thêm dữ liệu Bảng ProjGeneral - Thông tin chung dự án
        /// </summary>
        /// <param name="model">
        ///     Tạo List Error lưu lỗi nếu có
        ///     Add model truyền lên và saveChange nó
        /// </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjGeneralServiceModel model);

        /// <summary>
        /// Chỉnh sửa dữ liệu Bảng ProjGeneral - Thông tin chung dự án
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <returns>
        ///     Lưu lại giá trị của CreatedBy và CreatedDate
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjGeneralServiceModel model);

        /// <summary>
        /// Chỉnh sửa một số dữ liệu Bảng ProjGeneral - Thông tin chung dự án
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model hoặc object mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" 
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        /// <summary>
        /// Xóa dữ liệu Bảng ProjGeneral theo id - Thông tin chung dự án
        /// </summary>
        /// <param name="model">là một đối tượng model có thuộc tính id truyền vào</param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data vừa được xóa
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjGeneralServiceModel model);

        /// <summary>
        /// Tìm dữ liệu đầu tiên phù hợp model của Bảng ProjGeneral - Thông tin chung dự án
        /// </summary>
        /// <param name="model">là biểu thức điều kiện Where truyền lên hoặc id</param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data cột đầu tiên tìm thấy
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjGeneralServiceModel model);

        /// <summary>
        /// Đếm số row Bảng ProjGeneral theo điều kiện model - Thông tin chung dự án
        /// </summary>
        /// <param name="model"> là biểu thức điều kiện Where truyền lên</param>
        /// <returns>
        ///     Trả về số phần từ thỏa mãn điều kiện model
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        /// </returns>
        Task<(int data, List<ErrorModel> errors)> Count(Count_ProjGeneralServiceModel model);
    }

    public class ProjGeneralService : IProjGeneralService
    {
        private readonly ILogger<ProjGeneralService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        public readonly IProjWorksService _projWorksService;
        public readonly IPackageBidsService _packageBidsService;
        public readonly ICrService _crService;
        public readonly IIssueService _issueService;
        public readonly IProjectResourcesService _projectResourcesService;

        public ProjGeneralService(
            ILogger<ProjGeneralService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            IProjWorksService projWorksService,
            IPackageBidsService packageBidsService,
            ICrService crService,
            IIssueService issueService,
            IProjectResourcesService projectResourcesService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _projWorksService = projWorksService;
            _packageBidsService = packageBidsService;
            _crService = crService;
            _issueService = issueService;
            _projectResourcesService = projectResourcesService;
        }

        public int statusDelete { get => (int)StatusDb.Delete; }
        public IQueryable<ProjGeneral> _query
        {
            get => _db.ProjGeneral
                .Include(x => x.partner)
                .Include(x => x.projgroup)
                .Include(x => x.target)
                .Include(x => x.mntForm)
                .Include(x => x.invests)
                .Include(x => x.bidding)
                .Include(x => x.prod)
                .Include(x => x.status)
                .Include(x => x.projType)
                .Include(x => x.pmNam)
                .Include(x => x.serv)
                .Include(x => x.bizMod)
                .AsQueryable();
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ProjGeneralServiceModel model)
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ProjGeneralServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.ProjGeneral.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ProjGeneralServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.ProjGeneral.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.ProjGeneral.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ProjGeneralServiceModel model)
        {
            var errors = new List<ErrorModel>();
            using (var transaction = TransectionScopeExtension.Create())
            {
                try
                {
                    var data = await _db.ProjGeneral.Where(x => x.delete != statusDelete).FirstOrDefaultAsync(x => x.id == model.id);
                    var listprojWorkId = await _db.ProjWorks.Where(x => x.projGeneralId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listPackBidId = await _db.PackageBids.Where(x => x.projId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listCrId = await _db.Cr.Where(x => x.projId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listIssueId = await _db.Issue.Where(x => x.projId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();
                    var listProjReId = await _db.ProjectResources.Where(x => x.projId == model.id).Where(x => x.delete != statusDelete).Select(x => x.id).ToArrayAsync();

                    if (data == null)
                    {
                        errors.Add(new ErrorModel { key = "", value = "share.notExist" });
                    }

                    var checkerr = false;
                    // update value delete
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(new { delete = statusDelete }));
                    if (listPackBidId != null)
                    {
                        foreach (var id in listPackBidId)
                        {
                            var hasError = await _packageBidsService.Delete(new Delete_PackageBidsServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listprojWorkId != null)
                    {
                        foreach (var id in listprojWorkId)
                        {
                            var hasError = await _projWorksService.Delete(new Delete_ProjWorksServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listCrId != null)
                    {
                        foreach (var id in listCrId)
                        {
                            var hasError = await _crService.Delete(new Delete_CrServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listIssueId != null)
                    {
                        foreach (var id in listIssueId)
                        {
                            var hasError = await _issueService.Delete(new Delete_IssueServiceModel { id = id });
                            if (hasError.errors.Count > 0)
                            {
                                checkerr = true;
                                errors.AddRange(hasError.errors);
                            }
                        }
                    }
                    if (listProjReId != null)
                    {
                        foreach (var id in listProjReId)
                        {
                            var hasError = await _projectResourcesService.Delete(new Delete_ProjectResourcesServiceModel { id = id });
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
                            errors.Add(new ErrorModel { key = "", value = "ProjGeneral delete fail" });
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ProjGeneralServiceModel model)
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ProjGeneralServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.ProjGeneral.AsQueryable();
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

