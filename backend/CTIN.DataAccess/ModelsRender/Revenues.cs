using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Revenues
    {
        public string VouchersNumber { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public DateTime? DatePosted { get; set; }
        public DateTime? VouchersDate { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Classification { get; set; }
        public string Content { get; set; }
        public int? ExpItenId { get; set; }
        public int? Accountant { get; set; }
        public string ProjectId { get; set; }
        public int? ContractId { get; set; }
        public string FrameContract { get; set; }
        public int? BidId { get; set; }
        public decimal? Payments { get; set; }
        public string ImplementationSchedule { get; set; }
        public decimal? AmountOfMoney { get; set; }
        public decimal? Taxpay { get; set; }
        public decimal? AmountReceived { get; set; }
        public string PaymentType { get; set; }
        public int? PartId { get; set; }
        public string CoordinationList { get; set; }
        public int? EmpId { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Note { get; set; }
        public int Id { get; set; }
    }
}
