using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using CTIN.Domain.Services;
using CTIN.WebApi.Bases;
using CTIN.WebApi.Modules.AES;
using CTIN.WebApi.Modules.General.Models;
using CTIN.WebApi.Modules.JWT;
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
    public class ApplicationUserController : ApiController
    {
        private readonly IUserService _sv;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;
        public readonly ICurrentUserService _currentUserService;

        public ApplicationUserController(IUserService sv, ICurrentUserService currentUserService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _sv = sv;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
        }


        [HttpPost("Register")]
        //POST : /api/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.userName,
                Email = model.email,
                FullName = model.fullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.password);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost("Login")]
        //Post : /api/login
        public async Task<object> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.userName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.passWord))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
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
                return BadRequest(new { message = "Username or password is incorrect." });
            }
        }
    }
}
