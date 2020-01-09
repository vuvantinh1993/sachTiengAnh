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
using static CTIN.DataAccess.Models.IssueCauses;

namespace CTIN.WebApi.Modules.IssueCauses.Models
{

    public class Search_IssueCausesModel : Search_IssueCausesServiceModel
    {
    }

    public class Add_IssueCausesModel
    {
        public Add_IssueCausesModel_DataJson data { get; set; }
        public Add_IssueCausesModel_DataDbJson dataDb { get; set; }

        public class Add_IssueCausesModel_DataJson : IssueCausesDataJson
        {

        }

        public class Add_IssueCausesModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_IssueCausesModel : Add_IssueCausesModel
    {

    }

    public class FindOne_IssueCausesModel : FindOne_IssueCausesServiceModel
    {

    }

    public class Count_IssueCausesModel : Count_IssueCausesServiceModel
    {

    }
}
