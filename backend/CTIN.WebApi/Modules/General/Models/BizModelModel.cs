using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.BizModel;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_BizModelModel : Search_BizModelServiceModel
    {
    }
    public class Add_BizModelModel
    {
        public Add_BizModelModel_DataJson data { get; set; }
        public Add_BizModelModel_DataDbJson dataDb { get; set; }

        public class Add_BizModelModel_DataJson : BizModelDataJson
        {

        }

        public class Add_BizModelModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_BizModelModel : Add_BizModelModel
    {


    }

    public class FindOne_BizModelModel : FindOne_BizModelServiceModel
    {

    }

    public class Count_BizModelModel : Count_BizModelServiceModel
    {

    }
}
