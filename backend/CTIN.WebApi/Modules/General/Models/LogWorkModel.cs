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

    public class Search_LogWorkModel : Search_LogWorkServiceModel
    {
    }

    public class Add_LogWorkModel
    {
        [Required(ErrorMessage = "Required idemp")]
        public int idemp { get; set; }
        [MaxLength(500, ErrorMessage = "Vượt quá 500 kí tự")]
        public string content { get; set; }
    }

    public class Edit_LogWorkModel : Add_LogWorkModel
    {

    }

    public class FindOne_LogWorkModel : FindOne_LogWorkServiceModel
    {

    }

    public class Count_LogWorkModel : Count_LogWorkServiceModel
    {

    }
}
