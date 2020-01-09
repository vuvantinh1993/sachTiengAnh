using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class TimeSheet
    {
        public int id { get; set; }
        public int? projworkId { get; set; }
        public string topic { get; set; }
        public int? dateNumber { get; set; }
        public DateTime startDay { get; set; }
        public DateTime endDate { get; set; }
        public decimal? t2 { get; set; }
        public decimal? t3 { get; set; }
        public decimal? t4 { get; set; }
        public decimal? t5 { get; set; }
        public decimal? t6 { get; set; }
        public decimal? t7 { get; set; }
        public decimal? cn { get; set; }
        public int? delete { get; set; }

        public virtual ProjWorks projwork { get; set; }
    }
}
