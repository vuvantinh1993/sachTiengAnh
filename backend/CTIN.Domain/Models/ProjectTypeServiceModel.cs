using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ProjectTypeServiceModel : SearchModel
    {

    }

    public class Add_ProjectTypeServiceModel : ProjectType
    {

    }

    public class Edit_ProjectTypeServiceModel : ProjectType
    {

    }

    public class Delete_ProjectTypeServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_ProjectTypeServiceModel : WhereModel
    {
    }

    public class Count_ProjectTypeServiceModel : WhereModel
    {
    }
}
