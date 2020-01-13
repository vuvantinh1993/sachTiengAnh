using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.Domain.Models;
using CTIN.WebApi.Bases.Swagger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.User;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_UserModel : Search_UserServiceModel
    {
    }

    public class Add_UserModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public int? point { get; set; }
        public List<int> listfrendid { get; set; }
        public List<Add_UserModel_UserfilmleanningDataJson> filmleanning { get; set; }
        public Add_UserModel_DataDbJson dataDb { get; set; }
        public class Add_UserModel_DataDbJson
        {
            public int status { get; set; }
        }

        public class Add_UserModel_UserfilmleanningDataJson
        {
            public string namefilm { get; set; }
            public int positionword { get; set; }
        }
    }

    public class Edit_UserModel : Add_UserModel
    {
    }

    public class FindOne_UserModel : FindOne_UserServiceModel
    {

    }

    public class Count_UserModel : Count_UserServiceModel
    {

    }
}
