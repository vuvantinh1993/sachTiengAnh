using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class ExpectedCosts
    {
        public virtual int id { get; set; }

        public int? projectId { get; set; }
        public ExpectedCostsDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ExpectedCostsDataJson
        {
            public string currency { get; set; }
            public decimal exchangeRate { get; set; }
            public int expItemId { get; set; }
            public string costName { get; set; }
            public decimal percentage { get; set; }
            public decimal amountOfMoney { get; set; }
            public int? projectId { get; set; }
            public string note { get; set; }
        }
    }
}
