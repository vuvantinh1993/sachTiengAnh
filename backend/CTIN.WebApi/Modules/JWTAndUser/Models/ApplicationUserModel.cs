using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.JWTAndUser.Models
{
    public class ApplicationUserModel : ApplicationUserServiceModel
    {

    }
    public class LoginModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
    }
}
