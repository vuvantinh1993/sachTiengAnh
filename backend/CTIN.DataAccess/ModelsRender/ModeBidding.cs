using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class ModeBidding
    {
        public int Id { get; set; }
        public string Modebiddingname { get; set; }
        public int? Modebiddingindex { get; set; }
        public bool? Display { get; set; }
        public DateTime? Createdate { get; set; }
        public string Createby { get; set; }
        public DateTime? Modifydate { get; set; }
        public string Modifyby { get; set; }
        public string Note { get; set; }
    }
}
