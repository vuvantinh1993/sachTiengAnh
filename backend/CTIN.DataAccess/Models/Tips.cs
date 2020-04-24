using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    [Table("Tips")]
    public partial class Tips
    {
        public int id { get; set; }
        public string content { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
