using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ProjectProfileServiceModel : SearchModel
    {

    }

    public class Add_ProjectProfileServiceModel : ProjectProfile
    {

    }

    public class Edit_ProjectProfileServiceModel : ProjectProfile
    {

    }

    public class Delete_ProjectProfileServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ProjectProfileServiceModel : WhereModel
    {
    }

    public class Count_ProjectProfileServiceModel : WhereModel
    {
    }
}
