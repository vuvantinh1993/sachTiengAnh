using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ProjectGroup;

namespace CTIN.WebApi.Modules.General.Models
{


    public class Search_ProjectGroupModel : Search_ProjectGroupServiceModel
    {
    }

    public class Add_ProjectGroupModel
    {
        public Add_ProjectGroupModel_DataJson data { get; set; }
        public Add_ProjectGroupModel_DataDbJson dataDb { get; set; }

        public class Add_ProjectGroupModel_DataJson : ProjectGroupDataModelJson
        {

        }

        public class Add_ProjectGroupModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ProjectGroupModel : Add_ProjectGroupModel
    {


    }

    public class FindOne_ProjectGroupModel : FindOne_ProjectGroupServiceModel
    {

    }

    public class Count_ProjectGroupModel : Count_ProjectGroupServiceModel
    {

    }
}
