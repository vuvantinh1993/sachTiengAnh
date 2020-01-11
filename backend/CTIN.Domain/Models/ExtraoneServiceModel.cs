using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ExtraoneServiceModel : SearchModel
    {

    }

    public class Add_ExtraoneServiceModel : Extraone
    {

    }

    public class Edit_ExtraoneServiceModel : Extraone
    {

    }

    public class Delete_ExtraoneServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_ExtraoneServiceModel : WhereModel
    {
    }

    public class Count_ExtraoneServiceModel : WhereModel
    {
    }

}
