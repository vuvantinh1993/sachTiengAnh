using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.StorageCabinets;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_StorageCabinetsModel : Search_StorageCabinetsServiceModel
    {
    }
    public class Add_StorageCabinetsModel
    {
        public Add_StorageCabinetsModel_DataJson data { get; set; }
        public Add_StorageCabinetsModel_DataDbJson dataDb { get; set; }

        public class Add_StorageCabinetsModel_DataJson : StorageCabinetsDataJson
        {

        }

        public class Add_StorageCabinetsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_StorageCabinetsModel : Add_StorageCabinetsModel
    {


    }

    public class FindOne_StorageCabinetsModel : FindOne_StorageCabinetsServiceModel
    {

    }

    public class Count_StorageCabinetsModel : Count_StorageCabinetsServiceModel
    {

    }
}
