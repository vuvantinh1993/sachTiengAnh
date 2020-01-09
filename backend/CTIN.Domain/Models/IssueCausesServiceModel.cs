using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_IssueCausesServiceModel : SearchModel
    {

    }

    public class Add_IssueCausesServiceModel : IssueCauses
    {

    }

    public class Edit_IssueCausesServiceModel : IssueCauses
    {

    }

    public class Delete_IssueCausesServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_IssueCausesServiceModel : WhereModel
    {
    }

    public class Count_IssueCausesServiceModel : WhereModel
    {
    }

}
