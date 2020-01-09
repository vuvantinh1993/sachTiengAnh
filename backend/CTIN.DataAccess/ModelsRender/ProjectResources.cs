using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class ProjectResources
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int? PosId { get; set; }
        public int RoleName { get; set; }
        public int? PercentResource { get; set; }
        public string RelatedList { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? AllowDisplay { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ProjId { get; set; }
        public int? Delete { get; set; }
    }
}
