using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class RecruitmentApplicant
    {
        public long Id { get; set; }
        public string Basic { get; set; }
        public string Story { get; set; }
        public string Contact { get; set; }
        public string Accuracy { get; set; }
        public string Health { get; set; }
        public string Relationships { get; set; }
        public string Files { get; set; }
        public string Finance { get; set; }
        public string CapacityProfile { get; set; }
        public string TurnHistory { get; set; }
        public string DataDb { get; set; }
        public string Extend { get; set; }
        public string CurrentTurnId { get; set; }
    }
}
