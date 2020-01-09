using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TargetDetailServiceModel : SearchModel
    {

    }

    public class Add_TargetDetailServiceModel : TargetDetail
    {

    }

    public class Edit_TargetDetailServiceModel : TargetDetail
    {

    }

    public class Delete_TargetDetailServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_TargetDetailServiceModel : WhereModel
    {
    }

    public class Count_TargetDetailServiceModel : WhereModel
    {
    }
}
