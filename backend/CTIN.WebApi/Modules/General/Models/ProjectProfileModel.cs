using CTIN.Domain.Models;
using static CTIN.DataAccess.Models.ProjectProfile;

namespace CTIN.WebApi.Modules.General.Models
{
    public class ProjectProfileModel
    {
    }
    public class Search_ProjectProfileModel : Search_ProjectProfileServiceModel
    {
    }

    public class Add_ProjectProfileModel
    {
        public Add_ProjectProfileModel_DataJson data { get; set; }
        public Add_ProjectProfileModel_DataDbJson dataDb { get; set; }

        public class Add_ProjectProfileModel_DataJson : ProjectProfileDataJson
        {

        }

        public class Add_ProjectProfileModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ProjectProfileModel : Add_ProjectProfileModel
    {


    }

    public class FindOne_ProjectProfileModel : FindOne_ProjectProfileServiceModel
    {

    }

    public class Count_ProjectProfileModel : Count_ProjectProfileServiceModel
    {

    }
}
