using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class ActualCosts
    {
        public int id { get; set; }
        public virtual string vouchersNumber { get; set; }
        public ActualCostsDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ActualCostsDataJson
        {
            public DateTime? datePosted { get; set; }
            public DateTime? vouchersDate { get; set; }
            public int status { get; set; }
            public string currency { get; set; }
            public decimal? exchangeRate { get; set; }
            public int? expItenId { get; set; }
            public string costName { get; set; }
            public int accountant { get; set; }
            public int? projectId { get; set; }
            public int? contractId { get; set; }
            public string frameContract { get; set; }
            public int? bidId { get; set; }
            public decimal? payments { get; set; }
            public string implementationSchedule { get; set; }
            public decimal amountOfMoney { get; set; }
            public decimal taxpay { get; set; }
            public decimal amountReceived { get; set; }
            public int paymentType { get; set; }
            public int? partId { get; set; }
            public List<int> coordinationList { get; set; }
            public int? empId { get; set; }
            public int? index { get; set; }
            public string note { get; set; }
            public string classification { get; set; }
        }
    }
}
