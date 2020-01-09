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
    public class CurrencyController : ApiController
    {
        private readonly ICurrencyService _sv;
        public readonly ICurrentUserService _currentUserService;

        public CurrencyController(ICurrencyService sv, ICurrentUserService currentUserService)
        {
            _sv = sv;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Search_CurrencyModel model)
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
    }
}