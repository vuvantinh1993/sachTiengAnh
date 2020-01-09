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
using static CTIN.DataAccess.Models.Contractor;

namespace CTIN.WebApi.Modules.Contractor.Models
{

    public class Search_ContractorModel : Search_ContractorServiceModel
    {
    }

    public class Add_ContractorModel
    {
        public Add_ContractorModel_DataJson data { get; set; }
        public Add_ContractorModel_DataDbJson dataDb { get; set; }

        public class Add_ContractorModel_DataJson : ContractorDataJson
        {

        }

        public class Add_ContractorModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ContractorModel : Add_ContractorModel
    {

    }

    public class FindOne_ContractorModel : FindOne_ContractorServiceModel
    {

    }

    public class Count_ContractorModel : Count_ContractorServiceModel
    {

    }
}
