using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
     public class Search_ManagementFormServiceModel : SearchModel
    {

    }

    public class Add_ManagementFormServiceModel : ManagementForm
    {

    }

    public class Edit_ManagementFormServiceModel : ManagementForm
    {

    }

    public class Delete_ManagementFormServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ManagementFormServiceModel : WhereModel
    {
    }

    public class Count_ManagementFormServiceModel : WhereModel
    {
    }
}
