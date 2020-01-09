using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TrainningPlanEmployee
    {
        public int TrainningPlanId { get; set; }
        public long EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual TrainningPlan TrainningPlan { get; set; }
    }
}
