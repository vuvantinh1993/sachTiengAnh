using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTIN.DataAccess.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        public int star { get; set; }
        public int pointStage { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
