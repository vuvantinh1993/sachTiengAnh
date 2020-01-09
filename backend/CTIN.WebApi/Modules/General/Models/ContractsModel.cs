using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ContractsModel : Search_ContractsServiceModel
    {
    }

    public class Add_ContractsModel
    {
        public int projId { get; set; }
        public int packageBidsId { get; set; }
        public string contractCode { get; set; }
        public string contractName { get; set; }
        public DateTime? signedOn { get; set; }
        public string decisionNumber { get; set; }
        public DateTime? dateOfSignedDecision { get; set; }
        public string persionInChange { get; set; }
        public string contractClassification { get; set; }
        public int contractFormId { get; set; }
        public int statusId { get; set; }
        public string currency { get; set; }
        public decimal? exchangeRate { get; set; }
        public decimal? contractValue { get; set; }
        public decimal? deductibleValue { get; set; }
        public int termsOfPaymentId { get; set; }
        public int paymentTypeId { get; set; }
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
        public string createBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public int index { get; set; }

    }


    public class Edit_ContractsModel : Add_ContractsModel
    {

    }

    public class FindOne_ContractsModel : FindOne_ContractsServiceModel
    {

    }

    public class Count_ContractsModel : Count_ContractsServiceModel
    {

    }
}
