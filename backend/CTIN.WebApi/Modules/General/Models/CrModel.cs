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

    public class Search_CrModel : Search_CrServiceModel
    {
    }

    public class Add_CrModel
    {
        [Required(ErrorMessage = "projId Không được để trống")]
        public int? projId { get; set; }
        public int crtypeId { get; set; }
        [MaxLength(500, ErrorMessage = "Vượt quá 500 kí tự")]
        public string note { get; set; }
        [MaxLength(500, ErrorMessage = "Vượt quá 500 kí tự")]
        public string newvalue { get; set; }
        [MaxLength(500, ErrorMessage = "Vượt quá 500 kí tự")]
        public string oldvalue { get; set; }
    }

    public class Edit_CrModel : Add_CrModel
    {

    }

    public class FindOne_CrModel : FindOne_CrServiceModel
    {

    }

    public class Count_CrModel : Count_CrServiceModel
    {

    }
}
