using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ExpensesItemGroupServiceModel : SearchModel
    {

    }

    public class Add_ExpensesItemGroupServiceModel : ExpensesItemGroup
    {

    }

    public class Edit_ExpensesItemGroupServiceModel : ExpensesItemGroup
    {

    }

    public class Delete_ExpensesItemGroupServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ExpensesItemGroupServiceModel : WhereModel
    {
    }

    public class Count_ExpensesItemGroupServiceModel : WhereModel
    {
    }
}
