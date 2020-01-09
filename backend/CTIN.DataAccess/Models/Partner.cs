using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Partner
    {
        public int id { get; set; }
        public PartnerDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public ProjGeneral projGeneral { get; set; }

        public class PartnerDataJson
        {
            public string partCode { get; set; }
            public long? empId { get; set; }
            public string partnerNameVn { get; set; }
            public string partnerNameEn { get; set; }
            public int? idPartGroup { get; set; }
            public string taxCode { get; set; }
            public string classify { get; set; }
            public string sex { get; set; }
            public DateTime dateEstablish { get; set; }
            public string contact { get; set; }
            public DateTime birthday { get; set; }
            public string mobile { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string website { get; set; }
            public string fax { get; set; }
            public string note { get; set; }
        }
    }
}