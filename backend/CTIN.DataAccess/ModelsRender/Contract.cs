using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Contract
    {
        public long Id { get; set; }
        public long EmpId { get; set; }
        public string ContractNo { get; set; }
        public string DecisionNo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int? ContractTypeId { get; set; }
        public decimal? MonthNumber { get; set; }
        public decimal? Salary { get; set; }
        public int? Classify { get; set; }
        public long? OriginalNo { get; set; }
        public DateTime? SignDate { get; set; }
        public DateTime? TerminateDate { get; set; }
        public string Signature { get; set; }
        public int? CompanyId { get; set; }
        public string Content { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }

        public virtual ContractClassify ClassifyNavigation { get; set; }
        public virtual CompanyInfo Company { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Employees Emp { get; set; }
    }
}
