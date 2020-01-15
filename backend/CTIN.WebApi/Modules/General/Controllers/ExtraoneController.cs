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
using static CTIN.Domain.Models.Add_ExtraoneServiceModel;

namespace CTIN.WebApi.Modules.General.Controllers
{
    public class ExtraoneController : ApiController
    {
        private readonly IExtraoneService _sv;
        public readonly ICurrentUserService _currentUserService;

        public ExtraoneController(IExtraoneService sv, ICurrentUserService currentUserService)
        {
            _sv = sv;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_ExtraoneModel model)
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
        public async Task<object> Add([FromForm] Add_ExtraoneModel model)
        {
            if (ModelState.IsValid)
            {
                //set value default
                model.domain = GetDomain();
                model.dataDb = new Add_ExtraoneModel_DataDbJson()
                {
                    createdDate = DateTime.Now,
                    createdBy = Int32.Parse(_currentUserService.userId)
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
        public async Task<object> Edit(int id, [FromBody] Edit_ExtraoneModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Edit_ExtraoneServiceModel>();
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
                var modelService = new Delete_ExtraoneServiceModel { id = id };
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

        [HttpGet("FindOne")]
        public async Task<object> FindOne([FromQuery] FindOne_ExtraoneModel model)
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
                var result = await _sv.FindOne(new FindOne_ExtraoneServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_ExtraoneModel model)
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