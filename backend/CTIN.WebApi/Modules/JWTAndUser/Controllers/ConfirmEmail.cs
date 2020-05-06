using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.General.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.JWTAndUser.Controllers
{
    public class ConfirmEmail : ApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly NATemplateContext _db;
        private readonly ITipsService _sv;

        public ConfirmEmail(UserManager<ApplicationUser> userManager, NATemplateContext db, ITipsService sv)
        {
            _userManager = userManager;
            _db = db;
            _sv = sv;
        }

        [HttpGet("{userAndCode}")]
        public async Task<IActionResult> Get(string userAndCode)
        {
            var errors = new List<ErrorModel>();
            if (userAndCode != null)
            {
                var arr = userAndCode.Split("__");
                if (arr.Count() == 2)
                {
                    var user = await _userManager.FindByIdAsync(arr[0]);
                    if (user == null)
                    {
                        errors.Add(new ErrorModel { key = "userlogin", value = "Không tồn tại tài khoản" });
                        return await BindData(null, errors, null);
                    }
                    var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(arr[1]));
                    var result = await _userManager.ConfirmEmailAsync(user, code);
                    if (result.Succeeded)
                    {
                        return await BindData(new { result = "oke" }, null, null);
                    }
                    else
                    {
                        return await BindData(new { result = "notOke" }, errors, null);
                    }

                }
            }
            //if (ModelState.IsValid)
            //{
            //    var result = await _sv.Get(model);
            //    if (result.errors.Count == 0)
            //    {
            //        //new task  sent mail
            //        //push notification
            //    }
            //    return await BindData(result.data, result.errors, result.paging);
            //}

            return await BindData();
        }
    }
}
