using CTIN.Domain.Models;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_TipsModel : Search_TipsServiceModel
    {
    }

    public class Add_TipsModel
    {
        public string content { get; set; }
        public Add_TipsModel_DataDbJson dataDb { get; set; }
        public class Add_TipsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_TipsModel : Add_TipsModel
    {
    }

    public class FindOne_TipsModel : FindOne_TipsServiceModel
    {

    }

    public class Count_TipsModel : Count_TipsServiceModel
    {

    }
}
