using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TipsServiceModel : SearchModel
    {

    }

    public class Add_TipsServiceModel : Tips
    {

    }

    public class Edit_TipsServiceModel : Tips
    {

    }

    public class Delete_TipsServiceModel
    {
        public virtual int id { get; set; }
        public virtual string delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_TipsServiceModel : WhereModel
    {
    }

    public class Count_TipsServiceModel : WhereModel
    {
    }

}
