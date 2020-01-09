using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Target
    {
        public int id { get; set; }
        public TargetDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class TargetDataJson
        {
            public virtual string targetNameVn { get; set; }
            public virtual string targetNameEn { get; set; }
            public virtual string note { get; set; }
        }
    }
}