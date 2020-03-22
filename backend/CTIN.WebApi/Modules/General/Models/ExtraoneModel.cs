using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.Domain.Models;
using CTIN.WebApi.Bases.Swagger;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.Extraone;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ExtraoneModel : Search_ExtraoneServiceModel
    {
    }

    public class Add_ExtraoneModelaaaa
    {
        public IFormFile audio { get; set; }
    }

    public class Add_ExtraoneModel : Add_ExtraoneServiceModel
    {

    }

    public class Edit_ExtraoneModel : Add_ExtraoneModel
    {
    }

    public class FindOne_ExtraoneModel : FindOne_ExtraoneServiceModel
    {

    }

    public class Count_ExtraoneModel : Count_ExtraoneServiceModel
    {

    }
}
