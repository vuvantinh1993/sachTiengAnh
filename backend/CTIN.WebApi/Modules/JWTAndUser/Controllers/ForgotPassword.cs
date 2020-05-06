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

                        var callbackUrl = directoryBase + "/api/ChangePassWord/" + user.Id + "__" + code;
                        // yêu cầu xác thực email
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

        [HttpPost("ChangePassWord")]
        public async Task<Object> PostChangePassWord([FromBody] ChangePassWordModel model)
        {
            var errors = new List<ErrorModel>();
            if (ModelState.IsValid)
            {
                if (model.passWord != null)
                {

                }
                else
                {
                    errors.Add(new ErrorModel { key = "changePassWord", value = "PassWord không được để trống" });
                }

            }
            return await BindData();
        }
    }
}
