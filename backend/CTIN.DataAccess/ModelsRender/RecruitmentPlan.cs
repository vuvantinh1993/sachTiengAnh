using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class RecruitmentPlan
    {
        public long Id { get; set; }
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public string Request { get; set; }
        public string Channel { get; set; }
        public string Phase { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Require { get; set; }
        public string SignApproved { get; set; }
        public string Note { get; set; }
        public int? PlanStatus { get; set; }
        public string FileAttach { get; set; }
        public string DataExtend { get; set; }
        public string DataDb { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string CostIncurred { get; set; }
    }
}
