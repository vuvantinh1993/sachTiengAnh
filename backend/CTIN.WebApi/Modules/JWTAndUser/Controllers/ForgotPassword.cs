using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.JWTAndUser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.JWTAndUser.Controllers
{
    public class ForgotPassword : ApiController
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly IEmailSender _emailSender;

        public ForgotPassword(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _emailSender = emailSender;
        }

        [HttpPost("ForgotPassword")]
        public async Task<Object> PostForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var errors = new List<ErrorModel>();
            if (ModelState.IsValid)
            {
                if (model.email != null)
                {
                    var user = await _userManager.FindByEmailAsync(model.email);
                    if (user == null)
                    {
                        // Don't reveal that the user does not exist or is not confirmed
                        errors.Add(new ErrorModel { key = "forgotPassword", value = "Email không tồn tại trong hệ thống" });
                        return await BindData(new { result = "notOke" }, errors);
                    }
                    else
                    {
                        var directoryBase = Directory.GetCurrentDirectory();
                        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var password = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(model.password));

                        var callbackUrl = directoryBase + "/api/ForgotPassword/ChangePassWord/" + user.Id + "__" + code + "__" + password;
                        // gửi mail để thay đổi password
                    }
                }
                else
                {
                    errors.Add(new ErrorModel { key = "forgotPassword", value = "Email không được để trống" });
                }

                //return await BindData(result.data, result.errors);
            }
            return await BindData();
        }


        [HttpGet("ChangePassWord/{userAndCode}")]
        public async Task<IActionResult> Get(string userAndCode)
        {
            var errors = new List<ErrorModel>();
            if (userAndCode != null)
            {
                var arr = userAndCode.Split("__");
                if (arr.Count() == 3)
                {
                    var user = await _userManager.FindByIdAsync(arr[0]);
                    if (user == null)
                    {
                        errors.Add(new ErrorModel { key = "userlogin", value = "Không tồn tại tài khoản" });
                        return await BindData(null, errors, null);
                    }
                    var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(arr[1]));
                    var password = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(arr[2]));
                    var result = await _userManager.ResetPasswordAsync(user, code, password);
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
            return await BindData();
        }
    }
}
