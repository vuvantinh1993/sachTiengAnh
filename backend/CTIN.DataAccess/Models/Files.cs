using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Contexts
{
    public partial class Files
    {
        public virtual long id { get; set; }

        public virtual byte[] source { get; set; }
        public virtual FilesDataJson data { get; set; }
        public virtual DataDbJson dataDb { get; set; }

        public class FilesDataJson : IFileModel
        {
            public virtual string code { get; set; }

            public virtual string name { get; set; }

            public virtual string extension { get; set; }

            public virtual long size { get; set; }

            public virtual string url { get; set; }
        }
    }
}