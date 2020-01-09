using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class TimeSheetDetail
    {
        public virtual int id { get; set; }
        public int timeSheetId { get; set; }
        public List<DateTime> days { get; set; }
        public List<int> times { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
