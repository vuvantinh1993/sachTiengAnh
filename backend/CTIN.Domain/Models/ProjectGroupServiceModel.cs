using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;

namespace CTIN.Domain.Models
{
 
    public class Search_ProjectGroupServiceModel : SearchModel
    {

    }

    public class Add_ProjectGroupServiceModel : ProjectGroup
    {

    }

    public class Edit_ProjectGroupServiceModel : ProjectGroup
    {

    }

    public class Delete_ProjectGroupServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_ProjectGroupServiceModel : WhereModel
    {
    }

    public class Count_ProjectGroupServiceModel : WhereModel
    {
    }
}
