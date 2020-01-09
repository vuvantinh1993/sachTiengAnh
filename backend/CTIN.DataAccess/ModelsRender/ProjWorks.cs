using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Projworks
    {
        public int Id { get; set; }
        public int ProjGeneralId { get; set; }
        public string WorkName { get; set; }
        public int StatusId { get; set; }
        public int? WorkCompleted { get; set; }
        public int ClassifyWorks { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TimePlan { get; set; }
        public int? TimeReality { get; set; }
        public string Content { get; set; }
        public int EmpId { get; set; }
        public int? TargetId { get; set; }
        public string Note { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int? PerrentId { get; set; }
        public string Contact { get; set; }
        public string CoordinationList { get; set; }
        public int? Delete { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
