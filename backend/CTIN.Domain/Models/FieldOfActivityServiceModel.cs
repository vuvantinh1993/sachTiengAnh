using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_FieldOfActivityServiceModel : SearchModel
    {

    }

    public class Add_FieldOfActivityServiceModel : FieldOfActivity
    {

    }

    public class Edit_FieldOfActivityServiceModel : FieldOfActivity
    {

    }

    public class Delete_FieldOfActivityServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_FieldOfActivityServiceModel : WhereModel
    {
    }

    public class Count_FieldOfActivityServiceModel : WhereModel
    {
    }

}
