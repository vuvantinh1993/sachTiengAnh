using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CTIN.Domain.Services
{
    public interface IApplicationUserService
    {
        Task<(dynamic data, List<ErrorModel> errors)> register(ApplicationUserServiceModel model);
        //Task<(dynamic data, List<ErrorModel> errors)> Login(Add_CategoryfilmServiceModel model);
    }

    public class ApplicationUserService : IApplicationUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CategoryfilmService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;
        private SignInManager<ApplicationUser> _singInManager;

        public ApplicationUserService(ILogger<CategoryfilmService> log,
            NATemplateContext db,
            ICurrentUserService currentUserService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _singInManager = singInManager;
        }
        public async Task<(dynamic data, List<ErrorModel> errors)> register(ApplicationUserServiceModel model)
        {
            var errors = new List<ErrorModel>();
            bool checkerors = false;
            //var da = _db.use.AsQueryable();

            var applicationUser = new ApplicationUser()
            {
                UserName = model.userName,
                Email = model.email,
                FullName = model.fullName
            };
            var existEmail = await _userManager.FindByEmailAsync(model.email);
            if (existEmail != null)
            {
                checkerors = true;
                errors.Add(new ErrorModel { key = "email", value = "Email đã tồn tại" });
            }
            var existUserName = await _userManager.FindByNameAsync(model.userName);
            if (existUserName != null)
            {
                checkerors = true;
                errors.Add(new ErrorModel { key = "userName", value = "Tên người dùng đã tồn tại" });
            }
            if (checkerors == false)
            {
                try
                {
                    var result = await _userManager.CreateAsync(applicationUser, model.password);
                    if (result.Succeeded)
                    {
                        return (applicationUser, errors);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return (null, errors);
            }
            return (null, errors);
        }


        //public async Task<object> Login([FromBody] LoginModel model)
        //{
        //    var user = await _userManager.FindByNameAsync(model.userName);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.passWord))
        //    {
        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(new Claim[]
        //            {
        //                new Claim("UserID",user.Id.ToString())
        //            }),
        //            Expires = DateTime.UtcNow.AddDays(5),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        //        var token = tokenHandler.WriteToken(securityToken);
        //        return Ok(new { token });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Username or password is incorrect." });
        //    }
        //}
    }
}
