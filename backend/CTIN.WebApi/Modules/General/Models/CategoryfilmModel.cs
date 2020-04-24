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
using static CTIN.DataAccess.Models.Categoryfilm;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_CategoryfilmModel : Search_CategoryfilmServiceModel
    {
    }

    public class Add_CategoryfilmModel
    {
        public int level { get; set; }
        public string name { get; set; }
        public byte pointword { get; set; }
        public string discription { get; set; }
        public string linkImg { get; set; }
        public Add_CategoryfilmModel_DataDbJson dataDb { get; set; }
        public class Add_CategoryfilmModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_CategoryfilmModel : Add_CategoryfilmModel
    {
    }

    public class FindOne_CategoryfilmModel : FindOne_CategoryfilmServiceModel
    {

    }

    public class Count_CategoryfilmModel : Count_CategoryfilmServiceModel
    {

    }
}
