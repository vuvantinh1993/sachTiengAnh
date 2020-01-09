using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_RevenuesServiceModel : SearchModel
    {

    }

    public class Add_RevenuesServiceModel : Revenues
    {

    }

    public class Edit_RevenuesServiceModel : Revenues
    {

    }

    public class Delete_RevenuesServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_RevenuesServiceModel : WhereModel
    {
    }

    public class Count_RevenuesServiceModel : WhereModel
    {
    }

}
