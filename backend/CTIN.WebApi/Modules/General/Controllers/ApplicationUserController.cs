using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.AES;
using CTIN.WebApi.Modules.General.Models;
using CTIN.WebApi.Modules.JWT;
using CTIN.WebApi.Modules.System1.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.DataProtection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.General.Controllers
{
    public class ApplicationUserController : ApiController
    {
        private readonly IApplicationUserService _sv;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;
        public readonly ICurrentUserService _currentUserService;
        private readonly NATemplateContext _db;

        public ApplicationUserController(IApplicationUserService sv, ICurrentUserService currentUserService,
            NATemplateContext db,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettings> appSettings)
        {
            _sv = sv;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            _db = db;
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
                    // xác thực mail 

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
            }
            else
            {
                return BadRequest(new { message = "Username or password không đúng." });
            }
        }

        [HttpGet("GetProfile")]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = _currentUserService.userId;
            var user = await _userManager.FindByIdAsync(userId);
            var info = await _db.UserLeanning.Include(x => x.rank).FirstOrDefaultAsync(x => x.userId == userId);
            var info2 = from use in _db.UserLeanning
                        from ra in _db.Rank
                        where (use.point < ra.pointStage && use.point > ra.star)
                        select new
                        {
                            use.point,
                            ra.name
                        };
            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.address,
                user.avatar,
                info.point,
                namerank = info.rank.name,
            };
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("ForAdmin")]
        public string GetForAdmin()
        {
            return "Web for admin";
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("ForCustomer")]
        public string GetForCustomer()
        {
            return "Web for Customer";
        }

        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
        [Route("ForAdminOrCustomer")]
        public string GetForAdminOrCustomer()
        {
            return "Web for ForAdminOrCustomer";
        }
    }
}
