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
using static CTIN.DataAccess.Models.Extraone;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ExtraoneModel : Search_ExtraoneServiceModel
    {
    }

    public class Add_ExtraoneModel
    {
        public string audioquestion { get; set; }
        public string textquestion { get; set; }
        public string audioanswer { get; set; }
        public string textanswer { get; set; }
        public int categoryfilmid { get; set; }
        public List<int> doubtid { get; set; }
        public List<int> unselectid { get; set; }
        public Add_ExtraoneModel_DataDbJson dataDb { get; set; }
        public class Add_ExtraoneModel_DataDbJson
        {
            public int status { get; set; }
        }
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
