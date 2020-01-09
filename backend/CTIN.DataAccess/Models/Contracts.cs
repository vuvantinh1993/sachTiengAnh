using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Contracts
    {
        public int id { get; set; }
        public int? projId { get; set; }
        public int? packageBidsId { get; set; }
        public string contractCode { get; set; }
        public string contractName { get; set; }
        public DateTime? signedOn { get; set; }
        public string decisionNumber { get; set; }
        public DateTime? dateOfSignedDecision { get; set; }
        public string persionInChange { get; set; }
        public string contractClassification { get; set; }
        public int? contractFormId { get; set; }
        public int? statusId { get; set; }
        public string currency { get; set; }
        public decimal? exchangeRate { get; set; }
        public decimal? contractValue { get; set; }
        public decimal? deductibleValue { get; set; }
        public int? termsOfPaymentId { get; set; }
        public int? paymentTypeId { get; set; }
        public int? durationOfContract { get; set; }
        public DateTime? effectiveDate { get; set; }
        public DateTime? expiryDate { get; set; }
        public DateTime? dateOfAdvanceGuarantee { get; set; }
        public DateTime? endDateOfAdvGuar { get; set; }
        public int? percentAdvanceGuarantee { get; set; }
        public decimal? amountOfAdvGuar { get; set; }
        public DateTime? dateOfMakeAdvGuar { get; set; }
        public DateTime? endDateOfMakeAdvGuar { get; set; }
        public int? percentOfMakeAdvGuar { get; set; }
        public decimal? amountOfMakeAdvGuar { get; set; }
        public DateTime? warrantyEndDate { get; set; }
        public DateTime? liquidationDay { get; set; }
        public int? percentGuarOfWarranty { get; set; }
        public decimal? amountGuarOfWarranty { get; set; }
        public bool? allowDisplay { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public int index { get; set; }
        public int? delete { get; set; }


        public virtual ProjGeneral proj { get; private set; }
        public virtual PackageBids packageBids { get; private set; }
        public virtual ContractForm contractForm { get; private set; }
        public virtual Status status { get; private set; }
        public virtual PaymentType paymentType { get; private set; }
        public virtual TermsOfPayment termsOfPayment { get; private set; }
    }
}