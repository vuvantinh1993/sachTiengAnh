using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ExpensesItemGroup;

namespace CTIN.WebApi.Modules.General.Models
{
  

    public class Search_ExpensesItemGroupModel : Search_ExpensesItemGroupServiceModel
    {
    }

    public class Add_ExpensesItemGroupModel
    {
        public Add_ExpensesItemGroupModel_DataJson data { get; set; }
        public Add_ExpensesItemGroupModel_DataDbJson dataDb { get; set; }

        public class Add_ExpensesItemGroupModel_DataJson : ExpensesItemGroupDataJson
        {

        }

        public class Add_ExpensesItemGroupModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ExpensesItemGroupModel : Add_ExpensesItemGroupModel
    {


    }

    public class FindOne_ExpensesItemGroupModel : FindOne_ExpensesItemGroupServiceModel
    {

    }

    public class Count_ExpensesItemGroupModel : Count_ExpensesItemGroupServiceModel
    {

    }
}
