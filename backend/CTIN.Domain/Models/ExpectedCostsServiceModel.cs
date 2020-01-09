using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ExpectedCostsServiceModel : SearchModel
    {

    }

    public class Add_ExpectedCostsServiceModel : ExpectedCosts
    {

    }

    public class Edit_ExpectedCostsServiceModel : ExpectedCosts
    {

    }

    public class Delete_ExpectedCostsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ExpectedCostsServiceModel : WhereModel
    {
    }

    public class Count_ExpectedCostsServiceModel : WhereModel
    {
    }

}
