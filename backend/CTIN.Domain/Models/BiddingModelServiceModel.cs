using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_BiddingModelServiceModel : SearchModel
    {

    }

    public class Add_BiddingModelServiceModel : BiddingModel
    {

    }

    public class Edit_BiddingModelServiceModel : BiddingModel
    {

    }

    public class Delete_BiddingModelServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_BiddingModelServiceModel : WhereModel
    {
    }

    public class Count_BiddingModelServiceModel : WhereModel
    {
    }

}
