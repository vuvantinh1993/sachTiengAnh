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
using static CTIN.DataAccess.Models.BiddingModel;

namespace CTIN.WebApi.Modules.BiddingModel.Models
{

    public class Search_BiddingModelModel : Search_BiddingModelServiceModel
    {
    }

    public class Add_BiddingModelModel
    {
        public Add_BiddingModelModel_DataJson data { get; set; }
        public Add_BiddingModelModel_DataDbJson dataDb { get; set; }

        public class Add_BiddingModelModel_DataJson : BiddingModelDataJson
        {

        }

        public class Add_BiddingModelModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_BiddingModelModel : Add_BiddingModelModel
    {

    }

    public class FindOne_BiddingModelModel : FindOne_BiddingModelServiceModel
    {

    }

    public class Count_BiddingModelModel : Count_BiddingModelServiceModel
    {

    }
}
