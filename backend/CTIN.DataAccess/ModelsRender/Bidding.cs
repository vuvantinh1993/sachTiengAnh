using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Bidding
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string BiddingName { get; set; }
        public int? BiddingIndex { get; set; }
        public bool? AllowDisplay { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
