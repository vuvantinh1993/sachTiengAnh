using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ExpensesItemServiceModel : SearchModel
    {

    }

    public class Add_ExpensesItemServiceModel : ExpensesItem
    {

    }
    public class Edit_ExpensesItemServiceModel : ExpensesItem
    {

    }

    public class Delete_ExpensesItemServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ExpensesItemServiceModel : WhereModel
    {
    }

    public class Count_ExpensesItemServiceModel : WhereModel
    {
    }
}
