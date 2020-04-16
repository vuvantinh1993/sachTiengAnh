using CTIN.Common.Extentions;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using static CTIN.Domain.Models.FilesServiceModel;
using static CTIN.WebApi.Modules.System.Models.FileModel;

namespace tci.server.Modules.Stm.Controllers
{
    public class FileController : ApiController
    {
        private readonly IFileService _sv;
        public FileController(IFileService sv)
        {
            this._sv = sv;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_FileModel model)
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

        [HttpPost]
        public async Task<object> Add([FromForm] Add_FileModel model)
        {
            if (ModelState.IsValid)
            {
                model.domail = GetDomain();
                model.creationTime = DateTime.Now;
                model.creationBy = GetUserId();
                var result = await _sv.Add(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Dowload/{url}")]
        public async Task<IActionResult> Dowload([FromRoute]string url, int w = 0, int h = 0, int q = 100)
        {
            if (ModelState.IsValid)
            {
                var where = new JObject { new JProperty("data.code", url) }.JsonToString();
                var result = await _sv.FindOne(new FindOne_FilesServiceModel { where = where });
                if (result.errors.Count == 0 && result.data != null)
                {
                    return File(result.data.source, FileExtension.GetMimeType(result.data.data.extension));
                }
            }

            return await BindData();
        }


        [HttpDelete("{id}")]
        public async Task<object> Delete(long id)
        {
            if (ModelState.IsValid)
            {
                var modelService = new Delete_FilesServiceModel { id = id };
                var result = await _sv.Delete(modelService);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("FindOne")]
        public async Task<object> FindOne([FromQuery] FindOne_FileModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.FindOne(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("FindOneById/{id}")]
        public async Task<object> FindOne([FromRoute] long id)
        {
            if (ModelState.IsValid)
            {
                var where = JObject.FromObject(new { id }).JsonToString();
                var result = await _sv.FindOne(new FindOne_FilesServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_FileModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.Count(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        //[HttpGet]
        //public async Task<ActionResult> Ckfinder(Upload_FileModel model)
        //{
        //    model.width = model.width.HasValue ? model.width : 0;
        //    model.height = model.height.HasValue ? model.height : 0;
        //    model.flag = model.flag.HasValue() ? model.flag : "ckfinder";
        //    model.folder = model.folder.HasValue() ? model.folder : "ckfinder";
        //    return View("/Modules/Stm/Views/File/Ckfinder.cshtml", model);
        //}

        //[HttpPost]
        //public async Task<object> CkfinderData(Upload_FileModel model)
        //{
        //    model.width = model.width.HasValue ? model.width : 0;
        //    model.height = model.height.HasValue ? model.height : 0;
        //    model.flag = model.flag.HasValue() ? model.flag : "ckfinder";
        //    model.folder = model.folder.HasValue() ? model.folder : "ckfinder";
        //    if (ModelState.IsValid)
        //    {
        //        var result = await unit.Repository<FilesRepository>().Add(model, model.width.Value, model.height.Value, 100, (byte)Enums.Status_db.Nomal);
        //        var f = new JObject();
        //        if (result.data.Count > 0)
        //        {
        //            f = (result.data[0] as JObject);
        //            f.Add("uploaded", 1);
        //            f.Add("fileName", f["name"]);
        //            return f;
        //        }
        //        else
        //        {
        //            f.Add("uploaded", 0);
        //            f.Add("error", new JObject{ {"message", "Lỗi không tải được file"} });
        //            return f;
        //        }
        //    }
        //    return await BindData();
        //}       
    }
}