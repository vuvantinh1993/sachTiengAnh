using CTIN.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_PaymentScheduleModel : Search_PaymentScheduleServiceModel
    {
    }

    public class Add_PaymentScheduleModel
    {
        public int? contractId { get; set; }
        public int? handoverId { get; set; }
        public int? numberOfDay { get; set; }
        public DateTime? appointmentDate { get; set; }
        public decimal? amountOfMoney { get; set; }
        public int? numberOfPenaltyDays { get; set; }
        public DateTime? penaltyDate { get; set; }
        public int? penaltyRate { get; set; }
        public int? bonusRatio { get; set; }
        public int? numberOfBonusDays { get; set; }
        public DateTime? rewardDate { get; set; }
        public string explain { get; set; }
        public bool? allowDisplay { get; set; }
        public string note { get; set; }
        public int? projId { get; set; }
        public int? countOfPayment { get; set; }
        public string productCode { get; set; }
    }


    public class Edit_PaymentScheduleModel : Add_PaymentScheduleModel
    {

    }

    public class FindOne_PaymentScheduleModel : FindOne_PaymentScheduleServiceModel
    {

    }

    public class Count_PaymentScheduleModel : Count_PaymentScheduleServiceModel
    {

    }
}
