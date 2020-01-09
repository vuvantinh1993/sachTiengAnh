using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ProjectGroup
    {
        public int id { get; set; }
        public ProjectGroupDataModelJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ProjectGroupDataModelJson
        {
            public virtual string projGroupNameVN { get; set; }
            public virtual string projGroupNameEN { get; set; }
            public virtual int? projIndex { get; set; }
            public virtual int? projGrpCode { get; set; }
            public virtual string note { get; set; }
        }

    }
}