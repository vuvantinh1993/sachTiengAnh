using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class ExpectedCosts
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public DateTime? DateFounded { get; set; }
        public int? EmpId { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public int? ExpItemGroupId { get; set; }
        public string CostName { get; set; }
        public int? Percentage { get; set; }
        public decimal? AmountOfMoney { get; set; }
        public int? ProjectId { get; set; }
        public int? StatusPjojId { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
    }
}
