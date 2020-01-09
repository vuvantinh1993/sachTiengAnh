using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ProjectType;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_ProjectTypeModel : Search_ProjectTypeServiceModel
    {
    }

    public class Add_ProjectTypeModel
    {
        public Add_ProjectTypeModel_DataJson data { get; set; }
        public Add_ProjectTypeModel_DataDbJson dataDb { get; set; }

        public class Add_ProjectTypeModel_DataJson : ProjectTypeDataJson
        {

        }

        public class Add_ProjectTypeModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ProjectTypeModel : Add_ProjectTypeModel
    {


    }

    public class FindOne_ProjectTypeModel : FindOne_ProjectTypeServiceModel
    {

    }

    public class Count_ProjectTypeModel : Count_ProjectTypeServiceModel
    {

    }

}
