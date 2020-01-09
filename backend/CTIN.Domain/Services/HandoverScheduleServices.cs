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
    public interface IHandoverScheduleService
    {
        /// <summary>
        /// Lấy dữ liệu Bảng HandoverSchedule - Thông tin chung dự án
        /// </summary>
        /// <param name="model">
        ///     Model là biểu thức điều kiện Where truyền lên
        ///     Kiểm tra model truyền lên nếu có where thì query sẽ WhereLoopback
        ///     Query sẽ tiếp where theo OrderBy của client đưa lên, nếu client không đưa lên sẽ lấy giá trị mặc định cấu hình tại WebApi-Model
        ///     query sẽ tiếp where theo paging dữ liệu trả về là page(thông tin trang) và data(dữ liệu của trang cần lấy) 
        /// </param>
        /// <returns>
        ///     Trả về data gồm các Object (HandoverSchedule, partnerGroup, projectGroup,target, managementForms, invests, bidding, productServices, status, projectType)
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về paging (totalPage, count, order[{\"HandoverSchedule.id\": false}] , page, sizePage)
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_HandoverScheduleServiceModel model);

        /// <summary>
        /// Thêm dữ liệu Bảng HandoverSchedule - Thông tin chung dự án
        /// </summary>
        /// <param name="model">
        ///     Tạo List Error lưu lỗi nếu có
        ///     Add model truyền lên và saveChange nó
        /// </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_HandoverScheduleServiceModel model);

        /// <summary>
        /// Chỉnh sửa dữ liệu Bảng HandoverSchedule - Thông tin chung dự án
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <returns>
        ///     Lưu lại giá trị của CreatedBy và CreatedDate
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_HandoverScheduleServiceModel model);

        /// <summary>
        /// Chỉnh sửa một số dữ liệu Bảng HandoverSchedule - Thông tin chung dự án
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model hoặc object mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" 
        ///     Trả về data vừa được thêm mới
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        /// <summary>
        /// Xóa dữ liệu Bảng HandoverSchedule theo id - Thông tin chung dự án
        /// </summary>
        /// <param name="model">là một đối tượng model có thuộc tính id truyền vào</param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data vừa được xóa
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_HandoverScheduleServiceModel model);

        /// <summary>
        /// Tìm dữ liệu đầu tiên phù hợp model của Bảng HandoverSchedule - Thông tin chung dự án
        /// </summary>
        /// <param name="model">là biểu thức điều kiện Where truyền lên hoặc id</param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        ///     Trả về data cột đầu tiên tìm thấy
        /// </returns>
        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_HandoverScheduleServiceModel model);

        /// <summary>
        /// Đếm số row Bảng HandoverSchedule theo điều kiện model - Thông tin chung dự án
        /// </summary>
        /// <param name="model"> là biểu thức điều kiện Where truyền lên</param>
        /// <returns>
        ///     Trả về số phần từ thỏa mãn điều kiện model
        ///     Trả về errors kiểu dữ liệu "key , value" khi validate dữ liệu với database
        /// </returns>
        Task<(int data, List<ErrorModel> errors)> Count(Count_HandoverScheduleServiceModel model);
    }

    public class HandoverScheduleService : IHandoverScheduleService
    {
        private readonly ILogger<HandoverScheduleService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        private readonly IPaymentScheduleService _paymentScheduleService;

        public HandoverScheduleService(
            ILogger<HandoverScheduleService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            IPaymentScheduleService paymentScheduleService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _paymentScheduleService = paymentScheduleService;
        }

        public int statusDelete { get => (int)StatusDb.Delete; }
        public IQueryable<HandoverSchedule> _query
        {
            get => _db.HandoverSchedule
                    .Include(x => x.contracts)
                    .Include(x => x.status)
                    .Include(x => x.packageBid)
                    .Include(x => x.proj)
                    .Include(x => x.pay)
                    .Include(x => x.termPay)
                    .AsQueryable();
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_HandoverScheduleServiceModel model)
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_HandoverScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            _db.HandoverSchedule.Add(model);
            await _db.SaveChangesAsync();
            return (model, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_HandoverScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.HandoverSchedule.FirstOrDefaultAsync(x => x.id == id);
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
            var data = await _db.HandoverSchedule.FirstOrDefaultAsync(x => x.id == id);
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

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_HandoverScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.HandoverSchedule.Where(x => x.delete != statusDelete).FirstOrDefaultAsync(x => x.id == model.id);
            var listpaymentId = await _db.PaymentSchedule.Where(x => x.handoverId == model.id).Where(x => x.delete != statusDelete)
                .Select(x => x.id).ToArrayAsync();

            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }

            using (var transaction = TransectionScopeExtension.Create())
            {
                try
                {
                    var checkerr = false;
                    var update = new { delete = statusDelete };
                    _db.Entry(data).CurrentValues.SetValues(data.Patch(update));

                    // delete paymentSchedule
                    if (listpaymentId != null)
                    {
                        foreach (var id in listpaymentId)
                        {
                            var hasError = await _paymentScheduleService.Delete(new Delete_PaymentScheduleServiceModel { id = id });
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
                            errors.Add(new ErrorModel { key = "", value = "HandoverSchedule delete fail" });
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

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_HandoverScheduleServiceModel model)
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

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_HandoverScheduleServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var query = _db.HandoverSchedule.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback).Where(x => x.delete != statusDelete);
            }
            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}

