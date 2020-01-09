using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class Tips
    {
        public int id { get; set; }
        public string content { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
