using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TypeOfEducation
    {
        public TypeOfEducation()
        {
            Course = new HashSet<Course>();
            TrainningRequest = new HashSet<TrainningRequest>();
        }

        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string EduTypeCode { get; set; }
        public string EduTypeName { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public bool? AllowDisplay { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<TrainningRequest> TrainningRequest { get; set; }
    }
}
