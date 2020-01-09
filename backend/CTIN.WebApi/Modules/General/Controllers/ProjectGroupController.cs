using CTIN.Common.Extentions;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.General.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    public class ProjectGroupController : ApiController
    {
        private readonly IProjectGroupService _sv;
        public ProjectGroupController(IProjectGroupService sv)
        {
            this._sv = sv;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_ProjectGroupModel model)
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
        public async Task<object> Add([FromBody] Add_ProjectGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Add_ProjectGroupServiceModel>();
                var result = await _sv.Add(modelService);
                //set value default
                modelService.dataDb.createdDate = DateTime.Now;
                modelService.dataDb.createdBy = GetUserId();
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
        public async Task<object> Edit(int id, [FromBody] Edit_ProjectGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Edit_ProjectGroupServiceModel>();
                //set value default
                modelService.id = id;
                modelService.dataDb.modifiedDate = DateTime.Now;
                modelService.dataDb.modifiedBy = GetUserId();
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

        [HttpDelete("{id}")]
        public async Task<object> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var modelService = new Delete_ProjectGroupServiceModel { id = id };
                //set value default
                modelService.delectationTime = DateTime.Now;
                modelService.delectationBy = GetUserId();
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
        public async Task<object> FindOne([FromQuery] FindOne_ProjectGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.FindOne(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("FindOneById/{id}")]
        public async Task<object> FindOne([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                var where = JObject.FromObject(new { id }).JsonToString();
                var result = await _sv.FindOne(new FindOne_ProjectGroupServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_ProjectGroupModel model)
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