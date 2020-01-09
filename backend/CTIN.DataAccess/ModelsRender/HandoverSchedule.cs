using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class HandoverSchedule
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string HandoverClassification { get; set; }
        public int StatusId { get; set; }
        public string ProductName { get; set; }
        public string Content { get; set; }
        public int? ContractsId { get; set; }
        public string ContractCodeBase { get; set; }
        public int? PackageBidId { get; set; }
        public int ProjId { get; set; }
        public string Process { get; set; }
        public int? Mass { get; set; }
        public int? PercentMass { get; set; }
        public decimal? EstimatedValue { get; set; }
        public decimal? AcceptanceValue { get; set; }
        public int? PayId { get; set; }
        public int TermPayId { get; set; }
        public string BillNumber { get; set; }
        public DateTime? BillDate { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public DateTime EstimatedDate { get; set; }
        public int? Index { get; set; }
        public int? Delete { get; set; }
    }
}
