using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class IssueCauses
    {
        public int id { get; set; }
        public IssueCausesDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class IssueCausesDataJson
        {
            public virtual int issueId { get; set; }
            public virtual string issueCausesName { get; set; }
            public virtual int issueCausesIndex { get; set; }
            public virtual string note { get; set; }

            public virtual Issue issue { get; }

        }

    }
}