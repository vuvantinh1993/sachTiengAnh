using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.JWTAndUser.Models
{
    public class ForgotPasswordModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
