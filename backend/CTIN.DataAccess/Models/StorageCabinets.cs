using CTIN.Common.Models;
using System;

namespace CTIN.DataAccess.Models
{
    public partial class StorageCabinets
    {
        public virtual int id { get; set; }
        public StorageCabinetsDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class StorageCabinetsDataJson
        {
            public virtual string cabCode { get; set; }
            public virtual string cabinetName { get; set; }
            public virtual int amountCabin { get; set; }
            public virtual int empId { get; set; }
            public virtual string note { get; set; }

        }


    }
}
