using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class RecyclebBin
    {
        public int id { get; set; }
        public RecyclebBinDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class RecyclebBinDataJson
        {
            public virtual string tableName { get; set; }
            public virtual object valData { get; set; }
        }
    }
}