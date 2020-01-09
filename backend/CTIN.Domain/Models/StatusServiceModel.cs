using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;

namespace CTIN.Domain.Models
{

    public class Search_StatusServiceModel : SearchModel
    {

    }

    public class Add_StatusServiceModel : Status
    {

    }

    public class Edit_StatusServiceModel : Status
    {

    }

    public class Delete_StatusServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_StatusServiceModel : WhereModel
    {
    }

    public class Count_StatusServiceModel : WhereModel
    {
    }
}
