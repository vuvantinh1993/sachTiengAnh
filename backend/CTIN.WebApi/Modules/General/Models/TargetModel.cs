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
using static CTIN.DataAccess.Models.Target;

namespace CTIN.WebApi.Modules.Target.Models
{

    public class Search_TargetModel : Search_TargetServiceModel
    {
    }

    public class Add_TargetModel
    {
        public Add_TargetModel_DataJson data { get; set; }
        public Add_TargetModel_DataDbJson dataDb { get; set; }

        public class Add_TargetModel_DataJson: TargetDataJson{

        }

        public class Add_TargetModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TargetModel : Add_TargetModel
    {

    }

    public class FindOne_TargetModel : FindOne_TargetServiceModel
    {

    }

    public class Count_TargetModel : Count_TargetServiceModel
    {

    }
}
