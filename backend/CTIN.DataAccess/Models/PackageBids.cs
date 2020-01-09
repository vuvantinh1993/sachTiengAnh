using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class PackageBids
    {
        public int id { get; set; }
        public string packageBidName { get; set; }
        public int? projId { get; set; }
        public DateTime? startDay { get; set; }
        public DateTime? lastDay { get; set; }
        public int? statusId { get; set; }
        public string currency { get; set; }
        public decimal? estimatedPrice { get; set; }
        public decimal? bidPrice { get; set; }
        public decimal? bestBid { get; set; }
        public decimal? contractPrice { get; set; }
        public int? bidModelId { get; set; }
        public int? bidId { get; set; }
        public int? contractorId { get; set; }
        public object listEmpId { get; set; }
        public int? empId { get; set; }
        public int? partId { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string modifiedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string note { get; set; }
        public int? index { get; set; }
        public bool? allowDisplay { get; set; }
        public decimal? exchangeRate { get; set; }
        public int? delete { get; set; }

        public virtual ProjGeneral proj { get; private set; }
        public virtual Status status { get; private set; }
        public virtual BiddingModel bidModel { get; private set; }
        public virtual Bidding bid { get; private set; }
        public virtual Partner part { get; private set; }
        public virtual Contractor contractor { get; private set; }

    }
}