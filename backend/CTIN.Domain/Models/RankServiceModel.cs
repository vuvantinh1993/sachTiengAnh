using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_RankServiceModel : SearchModel
    {

    }

    public class Add_RankServiceModel : Rank
    {

    }

    public class Edit_RankServiceModel : Rank
    {

    }

    public class Delete_RankServiceModel
    {
        public virtual int id { get; set; }
        public virtual string delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_RankServiceModel : WhereModel
    {
    }

    public class Count_RankServiceModel : WhereModel
    {
    }

}
