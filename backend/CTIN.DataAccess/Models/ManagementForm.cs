using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ManagementForm
    {
        public virtual int id { get; set; }
        public ManagementFormDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ManagementFormDataJson
        {
            public virtual string mntFormName { get; set; }
            public virtual int mntFormIndex { get; set; }
            public virtual string note { get; set; }
        }

    }
}