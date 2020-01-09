using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class Acttachments
    {
        public int id { get; set; }
        public ActtachmentsfileDataJson fileData { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ActtachmentsfileDataJson
        {
            public int? projGeneral { get; set; }
            public int? biddingDocument { get; set; }
            public int? packageBids { get; set; }
            public int? contracts { get; set; }
            public int? projWorks { get; set; }
            public int? issue { get; set; }

            public int? fileId { get; set; }
            public float? capacity { get; set; }
            public int? version { get; set; }
            public string fileName { get; set; }
            public string fileData { get; set; }
            public string description { get; set; }
            public DateTime? uploadDate { get; set; }
            public string linkIn { get; set; }
            public string linkOut { get; set; }
            public int? storageCabinId { get; set; }
            public string key { get; set; }
        }
    }
}