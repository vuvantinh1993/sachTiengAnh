using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.General.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    public class BiddingController : ApiController
    {
        private readonly IBiddingService _sv;
        public readonly ICurrentUserService _currentUserService;

        public BiddingController(IBiddingService sv, ICurrentUserService currentUserService)
        {
            _sv = sv;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// lấy dữ liệu Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="model">
        ///     Model là biểu thức điều kiện Where truyền lên
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lên gọi tầng Domain lấy dữ liệu về
        ///     Nếu Không hợp lệ gọi làm BindDataa truyền BadRequest ra
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về paging (totalPage, count, page, sizePage)
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_BiddingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.Get(model);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors, result.paging);
            }
            return await BindData();
        }

        /// <summary>
        /// thêm dữ liệu Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="model">
        ///     Model là From dữ liệu được truyền lên
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ thì map Model truyền lên với Model csdl
        ///     Thêm dữ liệu các trường CretedBy, CreatedDate, modifiedBy, modifiedDate
        ///     Gọi tầng Domain và truyền dữ liệu sau khi map lên
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        /// </returns>
        [HttpPost]
        public async Task<object> Add([FromBody] Add_BiddingModel model)
        {
            var modelService = model.MapToObject<Add_BiddingServiceModel>();
            //set value default
            modelService.dataDb.createdDate = DateTime.Now;
            modelService.dataDb.createdBy = Int32.Parse(_currentUserService.userId);
            if (ModelState.IsValid)
            {

                var result = await _sv.Add(modelService);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// sửa dữ liệu Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <param>  
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ thì map Model truyền lên với Model csdl
        ///     Thêm dữ liệu các trường modifiedBy, modifiedDate
        ///     Gọi tầng Domain và truyền dữ liệu sau khi map lên
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        /// </returns>
        [HttpPut("{id}")]
        public async Task<object> Edit(int id, [FromBody] Edit_BiddingModel model)
        {

            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Edit_BiddingServiceModel>();
                //set value default
                modelService.id = id;
                modelService.dataDb.modifiedDate = DateTime.Now;
                modelService.dataDb.modifiedBy = Int32.Parse(_currentUserService.userId);
                var result = await _sv.Edit(id, modelService);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Chỉnh sửa một số dữ liệu Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="id"> là id của đối tượng cần chỉnh sửa </param>
        /// <param name="model"> là model hoặc object mới đưa lên để thay thế model cũ có id = id truyền vào </param>
        /// <param>
        ///     Kiểm tra Model truyền lên có dữ liệu không?
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Gọi tầng Domain và truyền id và object
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        /// </returns>
        [HttpPatch("{id}")]
        public async Task<object> Patch(int id, [FromBody] JObject model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "data not empty");
            }
            if (ModelState.IsValid)
            {
                //set value default
                var result = await _sv.Patch(id, model);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Xóa dữ liệu Bảng Bidding theo id - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="id"> là id của đối tượng cần xóa </param>
        /// <param>
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ Gọi tầng Domain và truyền id
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                var modelService = new Delete_BiddingServiceModel { id = id };
                //set value default
                modelService.delectationTime = DateTime.Now;
                modelService.delectationBy = Int32.Parse(_currentUserService.userId);
                var result = await _sv.Delete(modelService);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Tìm dữ liệu đầu tiên phù hợp model của Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="model">là biểu thức điều kiện Where truyền lên</param>
        ///  <param>
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ Gọi tầng Domain và truyền model(điều kiện Where)
        /// </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value" 
        ///     Trả về data cột đầu tiên tìm thấy
        /// </returns>
        [HttpGet("FindOne")]
        public async Task<object> FindOne([FromQuery] FindOne_BiddingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.FindOne(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Tìm dữ liệu đầu tiên phù hợp id của Bảng Bidding - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="id">là id của đối tượng cần tìm</param>
        /// <param>
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ Gọi tầng Domain và truyền id lên
        /// </param>
        /// <returns>
        ///     Trả về errors kiểu dữ liệu "key , value"
        ///     Trả về data cột đầu tiên tìm thấy
        /// </returns>
        [HttpGet("FindOneById/{id}")]
        public async Task<object> FindOneById([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var where = JObject.FromObject(new { id }).JsonToString();
                var result = await _sv.FindOne(new FindOne_BiddingServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Đếm số row Bảng Bidding theo điều kiện model - Lĩnh vực đấu thầu
        /// </summary>
        /// <param name="model"> là biểu thức điều kiện Where truyền lên</param>
        /// <param>
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ Gọi tầng Domain và truyền điều kiện model lên
        /// </param>
        /// <returns>
        ///     Trả về số phần từ thỏa mãn điều kiện model
        ///     Trả về errors kiểu dữ liệu "key , value" 
        /// </returns>
        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_BiddingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.Count(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }
    }
}