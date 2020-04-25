using System.Collections.Generic;
using System.Security.Claims;

namespace CTIN.Common.Interfaces
{
    public interface ICurrentUserService
    {
        ClaimsPrincipal user { get; }
        string userId { get; }
        bool isAuthenticated { get; }
        IEnumerable<string> roles { get; }
    }
}
