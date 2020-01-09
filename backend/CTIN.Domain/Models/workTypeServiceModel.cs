using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_WorkTypeServiceModel : SearchModel
    {

    }

    public class Add_WorkTypeServiceModel : WorkType
    {

    }

    public class Edit_WorkTypeServiceModel : WorkType
    {

    }

    public class Delete_WorkTypeServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_WorkTypeServiceModel : WhereModel
    {
    }

    public class Count_WorkTypeServiceModel : WhereModel
    {
    }

}
