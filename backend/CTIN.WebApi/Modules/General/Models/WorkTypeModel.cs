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
using static CTIN.DataAccess.Models.WorkType;

namespace CTIN.WebApi.Modules.WorkType.Models
{

    public class Search_WorkTypeModel : Search_WorkTypeServiceModel
    {
    }

    public class Add_WorkTypeModel
    {
        public Add_WorkTypeModel_DataJson data { get; set; }
        public Add_WorkTypeModel_DataDbJson dataDb { get; set; }

        public class Add_WorkTypeModel_DataJson : WorkTypeDataJson
        {

        }

        public class Add_WorkTypeModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_WorkTypeModel : Add_WorkTypeModel
    {

    }

    public class FindOne_WorkTypeModel : FindOne_WorkTypeServiceModel
    {

    }

    public class Count_WorkTypeModel : Count_WorkTypeServiceModel
    {

    }
}
