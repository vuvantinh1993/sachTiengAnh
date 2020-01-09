using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ProjProfileDetail;

namespace CTIN.WebApi.Modules.General.Models
{
   

    public class Search_ProjProfileDetailModel : Search_ProjProfileDetailServiceModel
    {
    }

    public class Add_ProjProfileDetailModel
    {
        public Add_ProjProfileDetailModel_DataJson data { get; set; }
        public Add_ProjProfileDetailModel_DataDbJson dataDb { get; set; }

        public class Add_ProjProfileDetailModel_DataJson : ProjProfileDetailDataModelJson
        {

        }

        public class Add_ProjProfileDetailModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ProjProfileDetailModel : Add_ProjProfileDetailModel
    {


    }

    public class FindOne_ProjProfileDetailModel : FindOne_ProjProfileDetailServiceModel
    {

    }

    public class Count_ProjProfileDetailModel : Count_ProjProfileDetailServiceModel
    {

    }
}
