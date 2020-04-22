using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.DataAccess.Models
{
    public class Rank
    {
        public int id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        public int start { get; set; }
        public int pointStage { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
