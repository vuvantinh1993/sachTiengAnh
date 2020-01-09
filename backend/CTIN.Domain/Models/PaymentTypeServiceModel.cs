using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_PaymentTypeServiceModel : SearchModel
    {

    }

    public class Add_PaymentTypeServiceModel : PaymentType
    {

    }

    public class Edit_PaymentTypeServiceModel : PaymentType
    {

    }

    public class Delete_PaymentTypeServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_PaymentTypeServiceModel : WhereModel
    {
    }

    public class Count_PaymentTypeServiceModel : WhereModel
    {
    }

}
