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
using static CTIN.DataAccess.Models.IssueType;

namespace CTIN.WebApi.Modules.IssueType.Models
{

    public class Search_IssueTypeModel : Search_IssueTypeServiceModel
    {
    }

    public class Add_IssueTypeModel
    {
        public Add_IssueTypeModel_DataJson data { get; set; }
        public Add_IssueTypeModel_DataDbJson dataDb { get; set; }

        public class Add_IssueTypeModel_DataJson : IssueTypeDataJson
        {

        }

        public class Add_IssueTypeModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_IssueTypeModel : Add_IssueTypeModel
    {

    }

    public class FindOne_IssueTypeModel : FindOne_IssueTypeServiceModel
    {

    }

    public class Count_IssueTypeModel : Count_IssueTypeServiceModel
    {

    }
}
