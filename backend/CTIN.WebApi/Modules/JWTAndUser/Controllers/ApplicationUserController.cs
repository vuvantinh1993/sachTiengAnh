using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.JWT;
using CTIN.WebApi.Modules.JWTAndUser.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.JWTAndUser.Controllers
{
    public class ApplicationUserController : ApiController
    {
        private readonly IApplicationUserService _sv;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;
        public readonly ICurrentUserService _currentUserService;
        private readonly NATemplateContext _db;
        private readonly IEmailSender _emailSender;

        public ApplicationUserController(IApplicationUserService sv, ICurrentUserService currentUserService,
            NATemplateContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings,
            IEmailSender emailSender)
        {
            _sv = sv;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            _db = db;
            _emailSender = emailSender;
        }


        [HttpPost("Register")]
        //POST : /api/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sv.register(model);
                if (result.errors.Count == 0)
                {
                    // Thêm user vảo userLeanning
                    var a = new UserLeanning();
                    a.userId = result.data.Id;
                    _db.UserLeanning.Add(a);

                    // xác thực mail 
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(result.data);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var userId = result.data.Id;
                    var callbackUrl = "https://localhost:5001/api/ConfirmEmail/" + userId + "__" + code;

                    await _emailSender.SendEmailAsync(result.data.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //string code = _userManager.GenerateEmailConfirmationTokenAsync(result.data);

                    //var callbackUrl = Url.Action(
                    //  "ConfirmEmail", "Account",
                    //  new { userId = result.data.Id, code = code },
                    //  protocol: Request.Url.Scheme);
                    //await _userManager.SendEmailAsync(user.Id,
                    //  "Confirm your account",
                    //  "Please confirm your account by clicking this link: <a href=\""
                    //                                  + callbackUrl + "\">link</a>");
                    //if (_singInManager.IsSignedIn(result.data) && User.IsInRole("Admin"))
                    //{

                    //}
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }


        [HttpPost("Login")]
        //Post : /api/login
        public async Task<object> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.passWord))
            {
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _option = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_option.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
                //if (await _userManager.IsEmailConfirmedAsync(user))
                //{
                //}
                //else
                //{
                //    var message = new List<string>();
                //    message.Add("Tài khoản của bạn chưa xác thực mail.");
                //    message.Add("Bạn hãy xác thực email trước khi đăng nhập.");
                //    return BadRequest(message);
                //}
            }
            else
            {
                var message = new List<string>();
                message.Add("Tài khoản hoặc mật khẩu không đúng.");
                return BadRequest(message);
            }
        }

        [HttpGet("GetProfile")]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = _currentUserService.userId;
            var user = await _userManager.FindByIdAsync(userId);
            var info = (from use in _db.UserLeanning
                        from ra in _db.Rank
                        where (use.userId == userId && use.point >= ra.pointStage && use.point < ra.pointmaxStage)
                        select new
                        {
                            use.point,
                            ra.name,
                            ra.star,
                            ra.pointmaxStage,
                            ra.pointStage
                        }).FirstOrDefault();
            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.address,
                user.avatar,
                info.point,
                namerank = info.name,
                info.star,
                pointLeverNext = info.pointmaxStage,
                info.pointStage
            };
        }


        [HttpPost("ChangeProfile")]
        [Authorize]
        public async Task<object> ChangeProfile([FromBody] ChangeprofileModel model)
        {
            if (ModelState.IsValid)
            {
                var modelService = model.MapToObject<ApplicationUser>();
                var result = await _sv.ChangeProfile(modelService);
                if (result.errors.Count == 0)
                {
                    //new task  sent mail
                    //push notification
                }
                return await BindData(result.data, result.errors);
            }
            return await BindData();
        }




        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //[Route("ForAdmin")]
        //public string GetForAdmin()
        //{
        //    return "Web for admin";
        //}

        //[HttpGet]
        //[Authorize(Roles = "Customer")]
        //[Route("ForCustomer")]
        //public string GetForCustomer()
        //{
        //    return "Web for Customer";
        //}

        //[HttpGet]
        //[Authorize(Roles = "Customer,Admin")]
        //[Route("ForAdminOrCustomer")]
        //public string GetForAdminOrCustomer()
        //{
        //    return "Web for ForAdminOrCustomer";
        //}
    }
}
