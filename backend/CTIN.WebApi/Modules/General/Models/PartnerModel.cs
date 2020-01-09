using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.Partner;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_PartnerModel : Search_PartnerServiceModel
    {
    }

    public class Add_PartnerModel
    {
        public Add_PartnerModel_DataJson data { get; set; }
        public Add_PartnerModel_DataDbJson dataDb { get; set; }

        public class Add_PartnerModel_DataJson : PartnerDataJson
        {

        }

        public class Add_PartnerModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_PartnerModel : Add_PartnerModel
    {


    }

    public class FindOne_PartnerModel : FindOne_PartnerServiceModel
    {

    }

    public class Count_PartnerModel : Count_PartnerServiceModel
    {

    }
}
