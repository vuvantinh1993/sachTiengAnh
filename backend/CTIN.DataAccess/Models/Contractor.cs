using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Contractor
    {
        public int id { get; set; }
        public ContractorDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ContractorDataJson
        {
            public virtual string contractorName { get; set; }
            public virtual int contractorIndex { get; set; }
            public virtual string note { get; set; }
        }

    }
}