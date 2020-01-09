using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class PartnerGroup
    {
        public int id { get; set; }
        public PartnerGroupDataModelJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class PartnerGroupDataModelJson{
            public virtual string partnerGroupNameVn { get; set; }
            public virtual string partnerGroupNameEn { get; set; }
            public virtual string note { get; set; }
        }
    }
}