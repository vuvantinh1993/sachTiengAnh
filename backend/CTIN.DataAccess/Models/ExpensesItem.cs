using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CTIN.DataAccess.Models
{
    public partial class ExpensesItem
    {
        public int id { get; set; }
        public ExpensesItemDataModelJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class ExpensesItemDataModelJson
        {
            public virtual int? expItemGroup { get; set; }
            public virtual string expensesItemName { get; set; }
            public virtual int expensesItemIndex { get; set; }
            public virtual string note { get; set; }
        }
       
    }
}