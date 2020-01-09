using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TargetServiceModel : SearchModel
    {

    }

    public class Add_TargetServiceModel : Target
    {

    }

    public class Edit_TargetServiceModel : Target
    {

    }

    public class Delete_TargetServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_TargetServiceModel : WhereModel
    {
    }

    public class Count_TargetServiceModel : WhereModel
    {
    }

}
