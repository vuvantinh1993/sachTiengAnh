using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ActualCostsServiceModel : SearchModel
    {

    }

    public class Add_ActualCostsServiceModel : ActualCosts
    {

    }

    public class Edit_ActualCostsServiceModel : ActualCosts
    {

    }

    public class Delete_ActualCostsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ActualCostsServiceModel : WhereModel
    {
    }

    public class Count_ActualCostsServiceModel : WhereModel
    {
    }

}
