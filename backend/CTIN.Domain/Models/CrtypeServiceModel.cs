using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{


     public class Search_CrtypeServiceModel : SearchModel
    {

    }

    public class Add_CrtypeServiceModel : Crtype
    {

    }

    public class Edit_CrtypeServiceModel : Crtype
    {

    }

    public class Delete_CrtypeServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_CrtypeServiceModel : WhereModel
    {
    }

    public class Count_CrtypeServiceModel : WhereModel
    {
    }
}
