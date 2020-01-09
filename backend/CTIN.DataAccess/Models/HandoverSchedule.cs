using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class HandoverSchedule
    {
        public int id { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string handoverClassification { get; set; }
        public int? statusId { get; set; }
        public string productName { get; set; }
        public string content { get; set; }
        public int? contractsId { get; set; }
        public string contractCodeBase { get; set; }
        public int? packageBidId { get; set; }
        public int? projId { get; set; }
        public string process { get; set; }
        public int? mass { get; set; }
        public int? percentMass { get; set; }
        public decimal? estimatedValue { get; set; }
        public decimal? acceptanceValue { get; set; }
        public int? payId { get; set; }
        public int? termPayId { get; set; }
        public string billNumber { get; set; }
        public DateTime? billDate { get; set; }
        public bool? allowDisplay { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public DateTime? estimatedDate { get; set; }
        public int? index { get; set; }
        public int? delete { get; set; }

        public virtual Status status { get; private set; }
        public virtual PackageBids packageBid { get; private set; }
        public virtual ProjGeneral proj { get; private set; }
        public virtual TermsOfPayment termPay { get; private set; }
        public virtual PaymentType pay { get; private set; }
        public virtual Contracts contracts { get; private set; }

    }
}
