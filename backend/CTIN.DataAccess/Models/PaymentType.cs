using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace CTIN.DataAccess.Models
{
    public partial class PaymentType
    {
        public virtual int id { get; set; }
        public PaymentTypeDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class PaymentTypeDataJson
        {
            public virtual string paymentTypeName { get; set; }
            public virtual string note { get; set; }
        }
    }

}


