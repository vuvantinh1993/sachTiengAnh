using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ExpensesItem;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ExpensesItemModel : Search_ExpensesItemServiceModel
    {
    }

    public class Add_ExpensesItemModel
    {
        public Add_ExpensesItemModel_DataJson data { get; set; }
        public Add_ExpensesItemModel_DataDbJson dataDb { get; set; }

        public class Add_ExpensesItemModel_DataJson : ExpensesItemDataModelJson
        {

        }

        public class Add_ExpensesItemModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ExpensesItemModel : Add_ExpensesItemModel
    {


    }

    public class FindOne_ExpensesItemModel : FindOne_ExpensesItemServiceModel
    {

    }

    public class Count_ExpensesItemModel : Count_ExpensesItemServiceModel
    {

    }
}
