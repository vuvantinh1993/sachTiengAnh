using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Acttachments
    {
        public int Id { get; set; }
        public string DataDb { get; set; }
        public string FileData { get; set; }
        public string Version { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string UploadDate { get; set; }
        public string LinkIn { get; set; }
        public string LinkOut { get; set; }
    }
}
