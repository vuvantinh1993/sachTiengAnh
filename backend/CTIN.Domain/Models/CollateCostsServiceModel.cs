using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_CollateCostsServiceModel : SearchModel
    {

    }

    public class Add_CollateCostsServiceModel : CollateCosts
    {

    }

    public class Edit_CollateCostsServiceModel : CollateCosts
    {

    }

    public class Delete_CollateCostsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_CollateCostsServiceModel : WhereModel
    {
    }

    public class Count_CollateCostsServiceModel : WhereModel
    {
    }

}
