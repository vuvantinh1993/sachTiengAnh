using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TrainingLecturers
    {
        public TrainingLecturers()
        {
            TrainningPlan = new HashSet<TrainningPlan>();
        }

        public int Id { get; set; }
        public string Data { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string DataDb { get; set; }

        public virtual ICollection<TrainningPlan> TrainningPlan { get; set; }
    }
}
