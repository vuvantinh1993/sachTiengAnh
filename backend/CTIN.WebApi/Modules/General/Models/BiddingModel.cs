using CTIN.Domain.Models;
using static CTIN.DataAccess.Models.Bidding;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_BiddingModel : Search_BiddingServiceModel
    {
    }

    public class Add_BiddingModel
    {
        public Add_BiddingModel_DataJson data { get; set; }
        public Add_BiddingModel_DataDbJson dataDb { get; set; }

        public class Add_BiddingModel_DataJson : BiddingDataJson
        {

        }

        public class Add_BiddingModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_BiddingModel : Add_BiddingModel
    {
         

    }

    public class FindOne_BiddingModel : FindOne_BiddingServiceModel
    {

    }

    public class Count_BiddingModel : Count_BiddingServiceModel
    {

    }
}
