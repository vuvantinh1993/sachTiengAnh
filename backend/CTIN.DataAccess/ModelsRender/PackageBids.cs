using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class PackageBids
    {
        public int Id { get; set; }
        public string PackageBidName { get; set; }
        public int ProjId { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? LastDay { get; set; }
        public int StatusId { get; set; }
        public string Currency { get; set; }
        public decimal? EstimatedPrice { get; set; }
        public decimal? BidPrice { get; set; }
        public decimal? BestBid { get; set; }
        public decimal? ContractPrice { get; set; }
        public int? BidModelId { get; set; }
        public int? BidId { get; set; }
        public int? ContractorId { get; set; }
        public string ListEmpId { get; set; }
        public int? EmpId { get; set; }
        public int? PartId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int? Index { get; set; }
        public bool? AllowDisplay { get; set; }
        public decimal? ExchangeRate { get; set; }
        public int? Delete { get; set; }
    }
}
