using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class PaymentSchedule
    {
        public int id { get; set; }
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
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public int? projId { get; set; }
        public int? countOfPayment { get; set; }
        public int? delete { get; set; }
        public string productCode { get; set; }

    }
}
