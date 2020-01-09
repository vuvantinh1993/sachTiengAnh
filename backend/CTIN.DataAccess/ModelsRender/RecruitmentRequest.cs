using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class RecruitmentRequest
    {
        public long Id { get; set; }
        public string RequestCode { get; set; }
        public string RequestName { get; set; }
        public long? Department { get; set; }
        public string JobPosition { get; set; }
        public int? Amount { get; set; }
        public decimal? ExpectedSalary { get; set; }
        public decimal? ExpectedSalaryUpTo { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public DateTime? ExpectedDateTo { get; set; }
        public int? RequestType { get; set; }
        public string Template { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string Require { get; set; }
        public string SignApproved { get; set; }
        public string Note { get; set; }
        public byte? RequestStatus { get; set; }
        public string DataExtend { get; set; }
        public string DataDb { get; set; }
    }
}
