using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ExpensesItemGroup
    {
        public int id { get; set; }
        public ExpensesItemGroupDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ExpensesItemGroupDataJson
        {
            public virtual string expensesItemGroupName { get; set; }
            public virtual string note { get; set; }
        }

    }
}