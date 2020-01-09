using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TrainningRequest
    {
        public TrainningRequest()
        {
            TrainningPlan = new HashSet<TrainningPlan>();
        }

        public int Id { get; set; }
        public int? PartnerId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Basic { get; set; }
        public string Cost { get; set; }
        public string Files { get; set; }
        public string DataDb { get; set; }
        public int? CourseId { get; set; }
        public int? TypeOfEducationId { get; set; }
        public int? ExpertId { get; set; }
        public int? CompanyInfoId { get; set; }

        public virtual CompanyInfo CompanyInfo { get; set; }
        public virtual Course Course { get; set; }
        public virtual Expert Expert { get; set; }
        public virtual TrainningPartner Partner { get; set; }
        public virtual TypeOfEducation TypeOfEducation { get; set; }
        public virtual ICollection<TrainningPlan> TrainningPlan { get; set; }
    }
}
