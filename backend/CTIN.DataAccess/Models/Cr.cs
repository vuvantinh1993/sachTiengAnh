using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class Cr
    {
        public int id { get; set; }
        public int? projId { get; set; }
        public int? crtypeId { get; set; }
        public string note { get; set; }
        public string newValue { get; set; }
        public string oldValue { get; set; }
        public int? delete { get; set; }

        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }

        public virtual ProjGeneral proj { get; private set; }
        public virtual Crtype crtype { get; private set; }
    }
}