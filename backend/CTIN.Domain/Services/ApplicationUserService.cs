using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace CTIN.Domain.Services
{
    public interface IApplicationUserService
    {
        Task<(dynamic data, List<ErrorModel> errors)> register(ApplicationUserServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> ChangeProfile(ApplicationUser model);
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

            model.role = "Customer";
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
                        await _userManager.AddToRoleAsync(applicationUser, model.role);

                        // đăng kí được tài khoản thêm tài khaonr vào userLeanning
                        var userLearnning = new UserLeanning
                        {
                            userId = await _userManager.GetUserIdAsync(applicationUser),
                            point = 0,
                            listFilmLearned = new List<filmlearnedJson>(),
                            filmLearnning = new List<wordleanedJson>(),
                            filmForgeted = new List<wordleanedJson>(),
                            filmPunishing = new List<wordleanedJson>(),
                            filmFinish = new List<wordleanedJson>(),
                            filmFinishForget = new List<wordleanedJson>()
                        };
                        _db.UserLeanning.Add(userLearnning);
                        if (await _db.SaveChangesAsync() > 0)
                        {
                            return (applicationUser, errors);
                        }
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(new ErrorModel { key = "error", value = "Không đăng kí được tài khoản" });
                    throw ex;
                }
            }
            else
            {
                return (null, errors);
            }
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> ChangeProfile(ApplicationUser model)
        {
            var errors = new List<ErrorModel>();
            var user = await _userManager.FindByIdAsync(_currentUserService.userId);
            if (model.avatar != null)
            {
                user.avatar = model.avatar;
                // xóa ảnh cũ trong thư mục
            }
            if (model.address != null)
            {
                user.address = model.address;
            }

            _db.Users.Add(user);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (new { user.avatar, user.address }, errors);
            }

            errors.Add(new ErrorModel { key = "error", value = "Hệ thống không thể thay đổi thông tin" });
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
