using CTIN.Domain.Models;
using static CTIN.DataAccess.Models.PartnerGroup;

namespace CTIN.WebApi.Modules.General.Models
{


    public class Search_PartnerGrouprModel : Search_PartnerGroupServiceModel
    {
    }

    public class Add_PartnerGrouprModel
    {
        public Add_PartneGrouprModel_DataJson data { get; set; }
        public Add_PartneGrouprModel_DataDbJson dataDb { get; set; }

        public class Add_PartneGrouprModel_DataJson : PartnerGroupDataModelJson
        {

        }

        public class Add_PartneGrouprModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_PartnerGrouprModel : Add_PartnerGrouprModel
    {


    }

    public class FindOne_PartnerGroupModel : FindOne_PartnerGroupServiceModel
    {

    }

    public class Count_PartnerGroupModel : Count_PartnerGroupServiceModel
    {

    }
}
