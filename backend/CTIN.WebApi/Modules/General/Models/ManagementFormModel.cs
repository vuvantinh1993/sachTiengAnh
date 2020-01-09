using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ManagementForm;

namespace CTIN.WebApi.Modules.General.Models
{


    public class Search_ManagementFormModel : Search_ManagementFormServiceModel
    {
    }
    public class Add_ManagementFormModel
    {
        public Add_ManagementFormModel_DataJson data { get; set; }
        public Add_ManagementFormModel_DataDbJson dataDb { get; set; }

        public class Add_ManagementFormModel_DataJson : ManagementFormDataJson
        {

        }

        public class Add_ManagementFormModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ManagementFormModel : Add_ManagementFormModel
    {


    }

    public class FindOne_ManagementFormModel : FindOne_ManagementFormServiceModel
    {

    }

    public class Count_ManagementFormModel : Count_ManagementFormServiceModel
    {

    }
}
