using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_HandoverScheduleModel : Search_HandoverScheduleServiceModel
    {
    }

    public class Add_HandoverScheduleModel
    {
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string handoverClassification { get; set; }

        [Required(ErrorMessage = "Required statusId")]
        public int? statusId { get; set; }
        public string productName { get; set; }
        public string content { get; set; }
        public int contractsId { get; set; }
        public string contractCodeBase { get; set; }
        public int? packageBidId { get; set; }
        public int? projId { get; set; }
        public string process { get; set; }
        public int? mass { get; set; }
        public int? percentMass { get; set; }
        public decimal? estimatedValue { get; set; }
        public decimal? acceptanceValue { get; set; }
        public int? payId { get; set; }
        public int termPayId { get; set; }
        public string billNumber { get; set; }
        public DateTime? billDate { get; set; }
        public bool? allowDisplay { get; set; }
        public string note { get; set; }
        public DateTime? estimatedDate { get; set; }
        public int? index { get; set; }

    }

    public class Edit_HandoverScheduleModel : Add_HandoverScheduleModel
    {
    }

    public class FindOne_HandoverScheduleModel : FindOne_HandoverScheduleServiceModel
    {

    }

    public class Count_HandoverScheduleModel : Count_HandoverScheduleServiceModel
    {

    }
}
