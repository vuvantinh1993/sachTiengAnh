using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.Crtype;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_CrtypeModel : Search_CrtypeServiceModel
    {
    }

    public class Add_CrtypeModel
    {
        public Add_CrtypeModel_DataJson data { get; set; }
        public Add_CrtypeModel_DataDbJson dataDb { get; set; }

        public class Add_CrtypeModel_DataJson : CrtypeDataJson
        {

        }

        public class Add_CrtypeModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_CrtypeModel : Add_CrtypeModel
    {


    }

    public class FindOne_CrtypeModel : FindOne_CrtypeServiceModel
    {

    }

    public class Count_CrtypeModel : Count_CrtypeServiceModel
    {

    }
}
