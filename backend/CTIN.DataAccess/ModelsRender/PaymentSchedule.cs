using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class PaymentSchedule
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int? HandoverId { get; set; }
        public int? NumberOfDay { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? AmountOfMoney { get; set; }
        public int? NumberOfPenaltyDays { get; set; }
        public DateTime? PenaltyDate { get; set; }
        public int? PenaltyRate { get; set; }
        public int? BonusRatio { get; set; }
        public int? NumberOfBonusDays { get; set; }
        public DateTime? RewardDate { get; set; }
        public string Explain { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int? CountOfPayment { get; set; }
        public int ProjId { get; set; }
        public int? Delete { get; set; }
        public string ProductCode { get; set; }
    }
}
