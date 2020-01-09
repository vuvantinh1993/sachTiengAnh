using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class TargetDetail
    {
        public int id { get; set; }
        public TargetDetailDataModelJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class TargetDetailDataModelJson
        {
            public virtual string targetDetailNameVn { get; set; }
            public virtual string targetDetailNameEn { get; set; }
            public virtual int stagePercent { get; set; }
            public virtual int? idtarget { get; set; }
            public virtual int stageIndex { get; set; }
            public virtual string stageColor { get; set; }
            public virtual string note { get; set; }

        }
    }
}