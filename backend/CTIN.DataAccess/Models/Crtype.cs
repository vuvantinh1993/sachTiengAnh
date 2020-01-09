using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    public partial class Crtype
    {
        public int id { get; set; }
        public CrtypeDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class CrtypeDataJson
        {
            public virtual string cRname { get; set; }
            public virtual string note { get; set; }
        }
    }
}