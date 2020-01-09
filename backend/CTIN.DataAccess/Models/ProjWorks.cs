
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ProjWorks
    {
        public int id { get; set; }
        public int? projGeneralId { get; set; }
        public int? perrentId { get; set; }
        public string workName { get; set; }
        public int? statusId { get; set; }
        public int workCompleted { get; set; }
        public int? classifyWorks { get; set; }
        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }
        public int timePlan { get; set; }
        public int timeReality { get; set; }
        public string content { get; set; }
        public int empId { get; set; }
        public int? targetId { get; set; }
        public string note { get; set; }
        public int? priority { get; set; }
        public string contact { get; set; }
        public object coordinationList { get; set; }
        public DateTime? completeDate { get; set; }
        public int? delete { get; set; }

        public virtual string createdBy { get; set; }
        public virtual DateTime createdDate { get; set; }
        public virtual string modifiedBy { get; set; }
        public virtual DateTime modifiedDate { get; set; }

        //public virtual ICollection<Target> target { get; set; }
        public virtual Target target { get; set; }
        public virtual ProjGeneral projGeneral { get; set; }
        public virtual Status status { get; set; }
    }
}