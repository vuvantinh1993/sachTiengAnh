using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.FieldOfActivity;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_FieldOfActivityModel : Search_FieldOfActivityServiceModel
    {
    }

    public class Add_FieldOfActivityModel
    {
        public Add_FieldOfActivityModel_DataJson data { get; set; }
        public Add_FieldOfActivityModel_DataDbJson dataDb { get; set; }

        public class Add_FieldOfActivityModel_DataJson : FieldOfActivityDataJson
        {

        }

        public class Add_FieldOfActivityModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_FieldOfActivityModel : Add_FieldOfActivityModel
    {


    }

    public class FindOne_FieldOfActivityModel : FindOne_FieldOfActivityServiceModel
    {

    }

    public class Count_FieldOfActivityModel : Count_FieldOfActivityServiceModel
    {

    }
}
