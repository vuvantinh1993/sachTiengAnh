using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_InvestsServiceModel : SearchModel
    {

    }

    public class Add_InvestsServiceModel : Invests
    {

    }

    public class Edit_InvestsServiceModel : Invests
    {

    }

    public class Delete_InvestsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_InvestsServiceModel : WhereModel
    {
    }

    public class Count_InvestsServiceModel : WhereModel
    {
    }
}
