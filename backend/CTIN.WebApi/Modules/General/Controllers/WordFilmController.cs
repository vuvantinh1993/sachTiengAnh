using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.General.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    [Authorize]
    public class WordFilmController : ApiController
    {
        private readonly IWordFilmService _sv;
        public readonly ICurrentUserService _currentUserService;

        public WordFilmController(IWordFilmService sv, ICurrentUserService currentUserService)
        {
            _sv = sv;
            _currentUserService = currentUserService;
        }

        [HttpGet("GetWord/{style}/{idfilm}")]
        public async Task<IActionResult> GetWord([FromRoute]string style, [FromRoute]int idfilm, [FromQuery] Search_WordFilmModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = await _sv.GetWord(style, idfilm, model);
                //if (result.errors.Count == 0)
                //{
                //    //new task  sent mail
                //    //push notification
                //}
                //return await BindData(result.data, result.errors, result.paging);
            }
            return await BindData();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_WordFilmModel model)
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
        [Authorize(Roles = "Admin")]
        public async Task<object> Add([FromForm] Add_WordFilmModel model)
        {
            if (ModelState.IsValid)
            {
                //set value default
                model.domain = GetDomain();
                model.dataDb = new Add_WordFilmModel_DataDbJson()
                {
                    createdDate = DateTime.Now,
                    createdBy = _currentUserService.userId
                };
                var result = await _sv.Add(model);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Edit(int id, [FromBody] Edit_WordFilmModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Edit_WordFilmServiceModel>();
                //set value default
                modelService.id = id;
                modelService.dataDb.modifiedDate = DateTime.Now;
                modelService.dataDb.modifiedBy = _currentUserService.userId;
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

        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
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

        [HttpGet("Dowload/{url}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Dowload([FromRoute]string url, int w = 0, int h = 0, int q = 100)
        {
            if (ModelState.IsValid)
            {
                var namenotExtention = Path.GetFileNameWithoutExtension(url);
                var where = new JObject { new JProperty("fullName", namenotExtention) }.JsonToString();
                var result = await _sv.FindOne(new FindOne_WordFilmServiceModel { where = where });
                if (result.errors.Count == 0 && result.data != null)
                {
                    var extention = Path.GetExtension(result.data.urlaudio);
                    return File(result.data.audio, FileExtension.GetMimeType(extention));
                }
            }

            return await BindData();
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var modelService = new Delete_WordFilmServiceModel { id = id };
                //set value default
                modelService.delectationTime = DateTime.Now;
                modelService.delectationBy = _currentUserService.userId;
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

        [HttpGet("FindOne")]
        public async Task<object> FindOne([FromQuery] FindOne_WordFilmModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.FindOne(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("FindOneById/{id}")]
        public async Task<object> FindOneById([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var where = JObject.FromObject(new { id }).JsonToString();
                var result = await _sv.FindOne(new FindOne_WordFilmServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_WordFilmModel model)
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