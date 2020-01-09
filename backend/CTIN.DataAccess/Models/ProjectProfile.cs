using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class ProjectProfile
    {
        public int id { get; set; }
        public ProjectProfileDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ProjectProfileDataJson
        {
            public virtual string profileNameVn { get; set; }
            public virtual string profileNameEn { get; set; }
            public virtual string profileCode { get; set; }
            public virtual string note { get; set; }
        }
    }
}