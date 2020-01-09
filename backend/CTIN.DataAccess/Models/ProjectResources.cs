using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class ProjectResources
    {
        public int id { get; set; }
        public int? empId { get; set; }
        public int? posId { get; set; }
        public int? projId { get; set; }
        public int? roleName { get; set; }
        public int? percentResource { get; set; }
        public object relatedList { get; set; }
        public DateTime? beginDate { get; set; }
        public DateTime? endDate { get; set; }
        public bool? allowDisplay { get; set; }
        public string note { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public int? delete { get; set; }

        public virtual ProjGeneral proj { get; set; }

    }
}
