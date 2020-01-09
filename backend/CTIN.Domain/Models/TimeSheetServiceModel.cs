using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TimeSheetServiceModel : SearchModel
    {

    }

    public class Add_TimeSheetServiceModel : TimeSheet
    {

    }

    public class Edit_TimeSheetServiceModel : TimeSheet
    {

    }

    public class Delete_TimeSheetServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
    }

    public class FindOne_TimeSheetServiceModel : WhereModel
    {
    }

    public class Count_TimeSheetServiceModel : WhereModel
    {
    }

}
