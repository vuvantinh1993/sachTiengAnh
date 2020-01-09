using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ProductServices
    {
        public int id { get; set; }
        public ProductServicesDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ProductServicesDataJson
        {
            public virtual string prodServNameVN { get; set; }
            public virtual string prodServNameEN { get; set; }
            public virtual string prodServCode { get; set; }
            public virtual int prodServ { get; set; }
            //mã dịch vụ
        }

    }
}