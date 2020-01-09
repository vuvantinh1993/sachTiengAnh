using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ProjectType
    {
        public int id { get; set; }
        public ProjectTypeDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ProjectTypeDataJson
        {

            public virtual string ProjTypeNameVn { get; set; }
            public virtual string projTypeNameEn { get; set; }
            public virtual string Note { get; set; }
            public virtual bool AllowDisplay { get; set; }

        }
    }
}