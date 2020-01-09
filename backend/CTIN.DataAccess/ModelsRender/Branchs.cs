using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Branchs
    {
        public long Id { get; set; }
        public long? ModelId { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string Files { get; set; }

        public virtual TableModel Model { get; set; }
    }
}
