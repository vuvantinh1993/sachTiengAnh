using CTIN.Common.Extentions;
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
    public class RecyclebBinController : ApiController
    {
        private readonly IRecyclebBinService _sv;
        public RecyclebBinController(IRecyclebBinService sv)
        {
            this._sv = sv;
        }

        /// <summary>
        /// lấy dữ liệu Bảng RecycleBin - Thùng rác
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
        public async Task<IActionResult> Get([FromQuery] Search_RecyclebBinModel model)
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
        /// Xóa dữ liệu Bảng RecycleBin theo id (đổi status = 3) - Thùng rác
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
                var modelService = new Delete_RecyclebBinServiceModel
                {
                    id = id,
                    delectationTime = DateTime.Now,
                    delectationBy = GetUserId()
                };
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
        /// khôi phục lại dữ liệu - Thùng rác
        /// </summary>
        /// <param name="id"> là id của đối tượng cần khôi phục </param>
        /// <param>
        ///     Kiểm tra ModelState xem có hợp lệ không
        ///     Nếu Model hợp lệ Gọi tầng Domain và truyền id
        /// </param>
        /// <returns>
        ///     Trả về data
        ///     Trả về errors kiểu dữ liệu "key , value"
        /// </returns>
        [HttpPut("Restore/{id}")]
        public async Task<object> Restore(int id)
        {
            if (ModelState.IsValid)
            {
                var modelService = new Restore_RecyclebBinServiceModel
                {
                    id = id
                };
                var result = await _sv.Restore(modelService);
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
        /// Tìm dữ liệu đầu tiên phù hợp model của Bảng RecycleBin - Thùng rác
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
        public async Task<object> FindOne([FromQuery] FindOne_RecyclebBinModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.FindOne(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Tìm dữ liệu đầu tiên phù hợp model của Bảng RecycleBin - Thùng rác
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
        public async Task<object> FindOneByID([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var where = JObject.FromObject(new { id }).JsonToString();
                var result = await _sv.FindOne(new FindOne_RecyclebBinServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        /// <summary>
        /// Đếm số row Bảng RecycleBin theo điều kiện model - Thùng rác
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
        public async Task<object> Count([FromQuery] Count_RecyclebBinModel model)
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