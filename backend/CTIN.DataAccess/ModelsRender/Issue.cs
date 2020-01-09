using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Issue
    {
        public int Id { get; set; }
        public int IssueTypeId { get; set; }
        public int StatusId { get; set; }
        public int? PercentCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int Priority { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TimePlan { get; set; }
        public int TimeReality { get; set; }
        public int EmpId { get; set; }
        public string Content { get; set; }
        public string CoordinationList { get; set; }
        public int ProjId { get; set; }
        public string ContactList { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int LevelIssue { get; set; }
        public string Solusion { get; set; }
        public string IssueName { get; set; }
        public int IssueCausesId { get; set; }
        public int Flag { get; set; }
        public int? Delete { get; set; }
    }
}
