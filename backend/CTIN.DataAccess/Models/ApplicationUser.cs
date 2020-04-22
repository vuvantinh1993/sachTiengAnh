using Microsoft.AspNetCore.Identity;

namespace CTIN.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
