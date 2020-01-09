using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class Categoryfilm
    {
        public int id { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public byte pointword { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
