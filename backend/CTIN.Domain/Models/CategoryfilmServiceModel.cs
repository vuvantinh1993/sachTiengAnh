using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_CategoryfilmServiceModel : SearchModel
    {

    }

    public class Add_CategoryfilmServiceModel : Categoryfilm
    {

    }

    public class Edit_CategoryfilmServiceModel : Categoryfilm
    {

    }

    public class Delete_CategoryfilmServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_CategoryfilmServiceModel : WhereModel
    {
    }

    public class Count_CategoryfilmServiceModel : WhereModel
    {
    }

}
