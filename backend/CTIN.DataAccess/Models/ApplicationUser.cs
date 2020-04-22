using CTIN.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace CTIN.DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string address { get; set; }
        public string avatar { get; set; }
    }
}
