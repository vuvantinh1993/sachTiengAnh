using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TimeSheetDetailServiceModel : SearchModel
    {

    }

    public class Add_TimeSheetDetailServiceModel : TimeSheetDetail
    {
        public virtual DateTime startDate { get; set; }

        public virtual DateTime endDate { get; set; }
    }

    public class Edit_TimeSheetDetailServiceModel : TimeSheetDetail
    {

    }

    public class Delete_TimeSheetDetailServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_TimeSheetDetailServiceModel : WhereModel
    {
    }

    public class Count_TimeSheetDetailServiceModel : WhereModel
    {
    }

}
