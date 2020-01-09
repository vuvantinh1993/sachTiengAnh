using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Invests
    {
        public virtual int id { get; set; }
        public InvestsDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class InvestsDataJson
        {
            public virtual string investName { get; set; }
            public virtual int investIndex { get; set; }
            public virtual string note { get; set; }
        }

    }
}