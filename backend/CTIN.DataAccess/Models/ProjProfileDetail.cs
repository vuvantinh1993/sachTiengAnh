using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class ProjProfileDetail
    {
        public int id { get; set; }
        public ProjProfileDetailDataModelJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ProjProfileDetailDataModelJson
        {
            public virtual string profDetailNameVn { get; set; }
            public virtual string profDetailNameEn { get; set; }
            public virtual int? idProjProfile { get; set; }
            public virtual int? idStatus { get; set; }
            public virtual int? profileDtlIndex { get; set; }
            public virtual string note { get; set; }

        }
    }
}