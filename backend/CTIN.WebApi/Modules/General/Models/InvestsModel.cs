using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.Invests;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_InvestsModel : Search_InvestsServiceModel
    {
    }

    public class Add_InvestsModel
    {
        public Add_InvestsModel_DataJson data { get; set; }
        public Add_InvestsModel_DataDbJson dataDb { get; set; }

        public class Add_InvestsModel_DataJson : InvestsDataJson
        {

        }

        public class Add_InvestsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_InvestsModel : Add_InvestsModel
    {


    }

    public class FindOne_InvestsModel : FindOne_InvestsServiceModel
    {

    }

    public class Count_InvestsModel : Count_InvestsServiceModel
    {

    }
}
