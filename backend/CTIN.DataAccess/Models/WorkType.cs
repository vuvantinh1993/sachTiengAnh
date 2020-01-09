using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class WorkType
    {
        public virtual int id { get; set; }
        public WorkTypeDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class WorkTypeDataJson
        {
            public string workTypeName { get; set; }
            public virtual int ratioTime { get; set; }
            public virtual int weight { get; set; }
            public virtual int ratioCost { get; set; }
            public int workTypeIndex { get; set; }
            public string note { get; set; }
        }
    }
}