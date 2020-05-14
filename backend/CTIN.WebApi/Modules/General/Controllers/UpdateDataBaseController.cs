using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.General.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    public class UpdateDataBaseController : ApiController
    {
        private readonly IUpdateDataBaseService _sv;
        public readonly ICurrentUserService _currentUserService;

        public UpdateDataBaseController(IUpdateDataBaseService sv, ICurrentUserService currentUserService)
        {
            _sv = sv;
            _currentUserService = currentUserService;
        }

        /// <summary>
        /// cần phải update cả 1 và 2 để lưu dữ liệu các từ
        /// </summary>
        /// <returns></returns>
        [HttpGet("updateWordDatabase1")]
        public async Task<IActionResult> updateWordDatabase1()
        {
            if (ModelState.IsValid)
            {
                var (data, errors, paging) = _sv.updateWordDatabase1();
                if (errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(data, errors, paging);
            }
            return await BindData();
        }

        [HttpGet("updateWordDatabase2")]
        public async Task<IActionResult> updateWordDatabase2()
        {
            if (ModelState.IsValid)
            {
                var (data, errors, paging) = _sv.updateWordDatabase2();
                if (errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(data, errors, paging);
            }
            return await BindData();
        }
    }
}