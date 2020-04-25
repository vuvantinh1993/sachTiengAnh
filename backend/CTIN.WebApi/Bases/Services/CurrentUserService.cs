using CTIN.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CTIN.WebApi.Bases.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal user => _httpContextAccessor.HttpContext?.User;

        public string userId => user?.FindFirst(ClaimTypes.NameIdentifier).Value;

        public bool isAuthenticated => userId != null;

        public IEnumerable<string> roles => isAuthenticated ? user.FindAll("role").Select(x => x.Value) : new string[] { };
    }
}
