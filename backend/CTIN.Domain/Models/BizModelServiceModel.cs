
using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_BizModelServiceModel : SearchModel
    {

    }

    public class Add_BizModelServiceModel : BizModel
    {

    }

    public class Edit_BizModelServiceModel : BizModel
    {

    }

    public class Delete_BizModelServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_BizModelServiceModel : WhereModel
    {
    }

    public class Count_BizModelServiceModel : WhereModel
    {
    }
}
