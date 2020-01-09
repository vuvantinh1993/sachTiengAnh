using CTIN.Common.Models;
using System;

namespace CTIN.DataAccess.Models
{
    public partial class ModeBidding
    {
        public virtual int id { get; set; }
        public string modebiddingname { get; set; }
        public int? modebiddingindex { get; set; }
        public bool? display { get; set; }
        public DateTime? createdate { get; set; }
        public string createby { get; set; }
        public DateTime? modifydate { get; set; }
        public string modifyby { get; set; }
        public string note { get; set; }

    }
}
