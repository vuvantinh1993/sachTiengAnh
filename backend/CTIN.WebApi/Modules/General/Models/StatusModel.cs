using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.Status;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_StatusModel : Search_StatusServiceModel
    {
    }
    public class Add_StatusModel
    {
        public Add_StatusModel_DataJson data { get; set; }
        public Add_StatusModel_DataDbJson dataDb { get; set; }

        public class Add_StatusModel_DataJson : StatusDataJson
        {

        }

        public class Add_StatusModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_StatusModel : Add_StatusModel
    {


    }

    public class FindOne_StatusModel : FindOne_StatusServiceModel
    {

    }

    public class Count_StatusModel : Count_StatusServiceModel
    {

    }
}
