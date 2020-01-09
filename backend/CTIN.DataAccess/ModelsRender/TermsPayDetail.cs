using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TermsPayDetail
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public int? TermsOfPayId { get; set; }
        public int? DayNumber { get; set; }
        public int? Rate { get; set; }
        public int? BonusRate { get; set; }
        public int? DurationBonus { get; set; }
        public int? PenaltyRate { get; set; }
        public int? DurationPenalty { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
