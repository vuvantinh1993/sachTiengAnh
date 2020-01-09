using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class BiddingDocuments
    {
        public int id { get; set; }
        public int? projId { get; set; }
        public int? packageBidsId { get; set; }
        public DateTime? dateOfBidSubmission { get; set; }
        public DateTime? submissionDate { get; set; }
        public DateTime? dateOfVerification { get; set; }
        public DateTime? datePassed { get; set; }
        public DateTime? dateOfApproval { get; set; }
        public string decisionNumber { get; set; }
        public DateTime? releaseDate { get; set; }
        public DateTime? adjustmentDate { get; set; }
        public DateTime? signedOn { get; set; }
        public object[] listEmpId { get; set; }
        public bool? allowDisplay { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public int? index { get; set; }
        public int? delete { get; set; }

        public virtual ProjGeneral proj { get; private set; }
        public virtual PackageBids packageBids { get; private set; }
    }
}