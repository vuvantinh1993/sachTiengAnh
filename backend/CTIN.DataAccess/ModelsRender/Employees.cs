using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Employees
    {
        public Employees()
        {
            TrainningPlanEmployee = new HashSet<TrainningPlanEmployee>();
        }

        public long Id { get; set; }
        public string Basic { get; set; }
        public string Story { get; set; }
        public string Contact { get; set; }
        public string Accuracy { get; set; }
        public string Health { get; set; }
        public string Relationships { get; set; }
        public string Files { get; set; }
        public string Finance { get; set; }
        public string Army { get; set; }
        public string RevolutionaryHistory { get; set; }
        public string DataDb { get; set; }
        public string PartyDelegation { get; set; }
        public string Federation { get; set; }
        public string Jobs { get; set; }
        public string Contracts { get; set; }
        public string CapacityProfile { get; set; }
        public string CurentJob { get; set; }
        public string DecisionHistory { get; set; }

        public virtual ICollection<TrainningPlanEmployee> TrainningPlanEmployee { get; set; }
    }
}
