using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Contracts
    {
        public int Id { get; set; }
        public int ProjId { get; set; }
        public int? PackageBidsId { get; set; }
        public string ContractCode { get; set; }
        public string ContractName { get; set; }
        public DateTime? SignedOn { get; set; }
        public string DecisionNumber { get; set; }
        public DateTime? DateOfSignedDecision { get; set; }
        public string PersionInChange { get; set; }
        public string ContractClassification { get; set; }
        public int? ContractFormId { get; set; }
        public int? StatusId { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? ContractValue { get; set; }
        public decimal? DeductibleValue { get; set; }
        public int? TermsOfPaymentId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int? DurationOfContract { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? DateOfAdvanceGuarantee { get; set; }
        public DateTime? EndDateOfAdvGuar { get; set; }
        public int? PercentAdvanceGuarantee { get; set; }
        public decimal? AmountOfAdvGuar { get; set; }
        public DateTime? DateOfMakeAdvGuar { get; set; }
        public DateTime? EndDateOfMakeAdvGuar { get; set; }
        public int? PercentOfMakeAdvGuar { get; set; }
        public decimal? AmountOfMakeAdvGuar { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public DateTime? LiquidationDay { get; set; }
        public int? PercentGuarOfWarranty { get; set; }
        public decimal? AmountGuarOfWarranty { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int? Index { get; set; }
        public int? Delete { get; set; }
    }
}
