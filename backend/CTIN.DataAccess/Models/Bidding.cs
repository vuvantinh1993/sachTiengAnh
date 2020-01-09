using CTIN.Common.Models;


namespace CTIN.DataAccess.Models
{
    public partial class Bidding
    {
        public virtual int id { get; set; }
        public BiddingDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class BiddingDataJson
        {
            public virtual string biddingName { get; set; }
            public virtual int biddingIndex { get; set; }
            public virtual string note { get; set; }
        }
    }

}


