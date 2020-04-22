using CTIN.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_RankModel : Search_RankServiceModel
    {
    }

    public class Add_RankModel
    {
        [StringLength(50)]
        public string name { get; set; }
        public int pointStage { get; set; }
        public Add_RankModel_DataDbJson dataDb { get; set; }
        public class Add_RankModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_RankModel : Add_RankModel
    {
    }

    public class FindOne_RankModel : FindOne_RankServiceModel
    {

    }

    public class Count_RankModel : Count_RankServiceModel
    {

    }
}
