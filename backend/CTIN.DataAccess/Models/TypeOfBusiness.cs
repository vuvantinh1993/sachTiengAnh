using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class TypeOfBusiness
    {
        public TypeOfBusiness()
        {
            CompanyInfo = new HashSet<CompanyInfo>();
        }

        public int id { get; set; }
        public TypeOfBusiness_DataJson data { get; set; }
        public DataDbJson dataDb { get; set; }
       
        public class TypeOfBusiness_DataJson
        {
            public string businessTypeCode { get; set; }
            public string businessTypeName { get; set; }
            public string description { get; set; }
            public int? index { get; set; }
            public bool? allowDisplay { get; set; }
        }

        public virtual ICollection<CompanyInfo> CompanyInfo { get; set; }
    }
}
