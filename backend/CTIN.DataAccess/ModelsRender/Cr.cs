using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Cr
    {
        public int Id { get; set; }
        public int ProjId { get; set; }
        public int? CrtypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Note { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int? Delete { get; set; }
    }
}
