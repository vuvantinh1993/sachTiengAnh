using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TimeSheet
    {
        public int Id { get; set; }
        public int ProjworkId { get; set; }
        public string Topic { get; set; }
        public int? DateNumber { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? T2 { get; set; }
        public decimal? T3 { get; set; }
        public decimal? T4 { get; set; }
        public decimal? T5 { get; set; }
        public decimal? T6 { get; set; }
        public decimal? T7 { get; set; }
        public decimal? Cn { get; set; }
        public int? Delete { get; set; }
    }
}
