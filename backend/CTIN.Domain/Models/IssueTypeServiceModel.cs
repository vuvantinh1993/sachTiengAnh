using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_IssueTypeServiceModel : SearchModel
    {

    }

    public class Add_IssueTypeServiceModel : IssueType
    {

    }

    public class Edit_IssueTypeServiceModel : IssueType
    {

    }

    public class Delete_IssueTypeServiceModel
    {
        public virtual int id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_IssueTypeServiceModel : WhereModel
    {
    }

    public class Count_IssueTypeServiceModel : WhereModel
    {
    }

}
