using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ProductServices;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ProductServicesModel : Search_ProductServicesServiceModel
    {
    }

    public class Add_ProductServicesModel
    {
        public Add_ProductServicesModel_DataJson data { get; set; }
        public Add_ProductServicesModel_DataDbJson dataDb { get; set; }

        public class Add_ProductServicesModel_DataJson : ProductServicesDataJson
        {

        }

        public class Add_ProductServicesModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ProductServicesModel : Add_ProductServicesModel
    {


    }

    public class FindOne_ProductServicesModel : FindOne_ProductServicesServiceModel
    {

    }

    public class Count_ProductServicesModel : Count_ProductServicesServiceModel
    {

    }
}
