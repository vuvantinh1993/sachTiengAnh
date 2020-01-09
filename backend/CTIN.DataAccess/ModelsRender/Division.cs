using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Division
    {
        public int Id { get; set; }
        public string DivCode { get; set; }
        public string DivName { get; set; }
        public int DepId { get; set; }
        public string Data { get; set; }
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

        public virtual Department Dep { get; set; }
    }
}
