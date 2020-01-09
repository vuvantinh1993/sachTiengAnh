using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.TargetDetail;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_TargetDetailModel : Search_TargetDetailServiceModel
    {
    }
    public class Add_TargetDetailModel
    {
        public Add_TargetDetailModel_DataJson data { get; set; }
        public Add_TargetDetailModel_DataDbJson dataDb { get; set; }

        public class Add_TargetDetailModel_DataJson : TargetDetailDataModelJson
        {

        }

        public class Add_TargetDetailModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TargetDetailModel : Add_TargetDetailModel
    {


    }

    public class FindOne_TargetDetailModel : FindOne_TargetDetailServiceModel
    {

    }

    public class Count_TargetDetailModel : Count_TargetDetailServiceModel
    {

    }
}
