using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.AES;
using CTIN.WebApi.Modules.General.Models;
using CTIN.WebApi.Modules.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    [Authorize]
    public class UserLeanningController : ApiController
    {
        private readonly IUserService _sv;
        public readonly ICurrentUserService _currentUserService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;

        public UserLeanningController(IUserService sv, ICurrentUserService currentUserService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _sv = sv;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_UserLeanningModel model)
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
        public async Task<object> Add([FromBody] Add_UserLeanningModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Add_UserLeanningServiceModel>();
                //set value default
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

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Edit(int id, [FromBody] Edit_UserLeanningModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<Edit_UserLeanningServiceModel>();
                //set value default
                modelService.id = id;
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var modelService = new Delete_UserLeanningServiceModel { id = id };
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
        public async Task<object> FindOne([FromQuery] FindOne_UserLeanningModel model)
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
                var result = await _sv.FindOne(new FindOne_UserLeanningServiceModel { where = where });
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("Count")]
        public async Task<object> Count([FromQuery] Count_UserLeanningModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.Count(model);
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }

        [HttpGet("updateWordlened")]
        public async Task<object> updateWordlened([FromQuery] Updatepoint_UserLeanningModel model)
        {
            var value = EncryptionHelper.DecryptStringAES(model.chuoimahoa).Split(":");
            int idfilm = Convert.ToInt32(value[0]);
            int sttWord = Convert.ToInt32(value[1]);
            int totalSentenceRight = Convert.ToInt32(value[2]);
            double speedVideo = Convert.ToDouble(value[3]);

            if (sttWord < -3 || totalSentenceRight > 10)
            {
                ModelState.AddModelError("updateWordlened", "data not empty");
            }
            if (ModelState.IsValid)
            {
                //var result = await _sv.updateWordlened(idfilm, sttWord, totalSentenceRight, speedVideo, model);
                //if (result.errors.Count == 0)
                //{
                //}
                //return await BindData(result.data, result.errors);
            }
            return await BindData();
        }
    }
}