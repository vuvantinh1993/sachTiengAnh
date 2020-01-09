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

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_TempModel : Search_TemplateServiceModel
    {
    }

    public class Add_TempModel
    {
        [Required(ErrorMessage = "Required name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Required address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Required dataDb")]
        public Add_TempModel_DataDbJson dataDb { get; set; }

        public class Add_TempModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TempModel : Add_TempModel
    {

    }

    public class FindOne_TempModel : FindOne_TemplateServiceModel
    {

    }

    public class Count_TempModel : Count_TemplateServiceModel
    {

    }
}
