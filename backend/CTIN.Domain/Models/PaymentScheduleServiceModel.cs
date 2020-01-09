using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_PaymentScheduleServiceModel : SearchModel
    {

    }

    public class Add_PaymentScheduleServiceModel : PaymentSchedule
    {

    }

    public class Edit_PaymentScheduleServiceModel : PaymentSchedule
    {

    }

    public class Delete_PaymentScheduleServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
        public virtual int? delete { get; set; }
    }

    public class FindOne_PaymentScheduleServiceModel : WhereModel
    {
    }

    public class Count_PaymentScheduleServiceModel : WhereModel
    {
    }

}
