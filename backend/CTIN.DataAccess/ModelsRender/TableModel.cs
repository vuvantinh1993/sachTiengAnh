using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TableModel
    {
        public TableModel()
        {
            Branchs = new HashSet<Branchs>();
        }

        public long Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string Files { get; set; }

        public virtual ICollection<Branchs> Branchs { get; set; }
    }
}
