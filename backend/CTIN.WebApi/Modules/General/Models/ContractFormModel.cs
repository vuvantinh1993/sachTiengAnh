using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ContractForm;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ContractFormModel : Search_ContractFormServiceModel
    {
    }

    public class Add_ContractFormModel
    {
        public Add_ContractFormModel_DataJson data { get; set; }
        public Add_ContractFormModel_DataDbJson dataDb { get; set; }

        public class Add_ContractFormModel_DataJson : ContractFormDataJson
        {

        }

        public class Add_ContractFormModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ContractFormModel : Add_ContractFormModel
    {


    }

    public class FindOne_ContractFormModel : FindOne_ContractFormServiceModel
    {

    }

    public class Count_ContractFormModel : Count_ContractFormServiceModel
    {

    }
}
