using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    [Table("Categoryfilm")]
    public partial class Categoryfilm
    {
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public byte pointword { get; set; }
        public DataDbJson dataDb { get; set; }
        public string discription { get; set; }
        public string linkImg { get; set; }
        public int totalWord { get; set; }
        public int totalUser { get; set; }
    }
}
