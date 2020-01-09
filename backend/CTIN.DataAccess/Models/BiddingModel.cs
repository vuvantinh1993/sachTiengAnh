using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class BiddingModel
    {
        public virtual int id { get; set; }
        public BiddingModelDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class BiddingModelDataJson
        {
            public virtual string binddingModelName { get; set; }
            public virtual int binddingModelIndex { get; set; }
            public virtual string note { get; set; }
        }
    }
}