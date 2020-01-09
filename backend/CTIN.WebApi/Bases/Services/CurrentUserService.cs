using CTIN.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CTIN.WebApi.Bases.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            user = httpContextAccessor.HttpContext?.User;
            userId = "0";
            isAuthenticated = userId != null;
            roles = isAuthenticated ? user.FindAll("role").Select(x => x.Value) : new string[] { };
        }

        public ClaimsPrincipal user { get; }

        public string userId { get; }

        public bool isAuthenticated { get; }

        public IEnumerable<string> roles { get; }
    }
}
