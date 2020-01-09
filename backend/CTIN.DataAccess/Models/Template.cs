using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class Template
    {
        public virtual Guid id { get; set; } = Guid.NewGuid();
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual DataDbJson dataDb { get; set; }
    }
}