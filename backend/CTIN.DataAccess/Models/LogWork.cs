using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class LogWork
    {
        public virtual int id { get; set; }
        public virtual DateTime currentdate { get; set; }
        public virtual int emmpId { get; set; }
        public virtual string content { get; set; }
    }
    
    
}
