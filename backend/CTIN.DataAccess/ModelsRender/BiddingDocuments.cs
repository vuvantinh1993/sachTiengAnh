using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class BiddingDocuments
    {
        public int Id { get; set; }
        public int ProjId { get; set; }
        public int PackageBidsId { get; set; }
        public DateTime? DateOfBidSubmission { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? DateOfVerification { get; set; }
        public DateTime? DatePassed { get; set; }
        public DateTime? DateOfApproval { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AdjustmentDate { get; set; }
        public DateTime? SignedOn { get; set; }
        public string ListEmpId { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int? Index { get; set; }
        public int? Delete { get; set; }
    }
}
