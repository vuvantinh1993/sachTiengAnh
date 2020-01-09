using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TrainningPlan
    {
        public TrainningPlan()
        {
            TrainningPlanEmployeeNavigation = new HashSet<TrainningPlanEmployee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DataDb { get; set; }
        public int? PartnerId { get; set; }
        public int? TrainningRequestId { get; set; }
        public int? TrainingLecturersId { get; set; }
        public string Result { get; set; }
        public string Commitment { get; set; }
        public string Basic { get; set; }
        public string Cost { get; set; }
        public string Files { get; set; }
        public string TrainningPlanEmployee { get; set; }
        public int? PerformanceId { get; set; }

        public virtual TrainningPartner Partner { get; set; }
        public virtual TrainingLecturers TrainingLecturers { get; set; }
        public virtual TrainningRequest TrainningRequest { get; set; }
        public virtual ICollection<TrainningPlanEmployee> TrainningPlanEmployeeNavigation { get; set; }
    }
}
