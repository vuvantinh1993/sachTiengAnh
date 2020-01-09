using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Department
    {
        public Department()
        {
            Division = new HashSet<Division>();
        }

        public int Id { get; set; }
        public string DepCode { get; set; }
        public string DepName { get; set; }
        public int CompanyId { get; set; }
        public string Data { get; set; }
        public string DataInfo { get; set; }
        public string DataDb { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
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

        public virtual CompanyInfo Company { get; set; }
        public virtual ICollection<Division> Division { get; set; }
    }
}
