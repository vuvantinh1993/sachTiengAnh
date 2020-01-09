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
using static CTIN.DataAccess.Models.TimeSheetDetail;

namespace CTIN.WebApi.Modules.TimeSheetDetail.Models
{

    public class Search_TimeSheetDetailModel : Search_TimeSheetDetailServiceModel
    {
    }

    public class Add_TimeSheetDetailModel
    {
        public virtual int id { get; set; }
        public int timeSheetId { get; set; }
        public List<DateTime> days { get; set; }
        public List<int> times { get; set; }
        public Add_TimeSheetDetailModel_DataDbJson dataDb { get; set; }

        public class Add_TimeSheetDetailModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TimeSheetDetailModel : Add_TimeSheetDetailModel
    {

    }

    public class FindOne_TimeSheetDetailModel : FindOne_TimeSheetDetailServiceModel
    {

    }

    public class Count_TimeSheetDetailModel : Count_TimeSheetDetailServiceModel
    {

    }
}
