using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Files
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public byte[] Source { get; set; }
    }
}
