using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_PackageBidsServiceModel : SearchModel
    {

    }

    public class Add_PackageBidsServiceModel : PackageBids
    {

    }

    public class Edit_PackageBidsServiceModel : PackageBids
    {

    }

    public class Delete_PackageBidsServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
        public virtual int delete { get; set; }
    }

    public class FindOne_PackageBidsServiceModel : WhereModel
    {
    }

    public class Count_PackageBidsServiceModel : WhereModel
    {
    }

}
