using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ProjWorksServiceModel : SearchModel
    {

    }

    public class Add_ProjWorksServiceModel : ProjWorks
    {

    }

    public class Edit_ProjWorksServiceModel : ProjWorks
    {

    }

    public class Delete_ProjWorksServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
        public virtual int? delete { get; set; }
    }

    public class FindOne_ProjWorksServiceModel : WhereModel
    {
    }

    public class Count_ProjWorksServiceModel : WhereModel
    {
    }

}
