using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_CrServiceModel : SearchModel
    {

    }

    public class Add_CrServiceModel : Cr
    {

    }

    public class Edit_CrServiceModel : Cr
    {

    }

    public class Delete_CrServiceModel
    {
        public virtual int id { get; set; }
        public virtual int? delete { get; set; }

    }

    public class FindOne_CrServiceModel : WhereModel
    {
    }

    public class Count_CrServiceModel : WhereModel
    {
    }

}
