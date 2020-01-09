using CTIN.Common.Models;
using CTIN.DataAccess.Models;

namespace CTIN.Domain.Models
{
    public class Search_IssueServiceModel : SearchModel
    {

    }

    public class Add_IssueServiceModel : Issue
    {

    }

    public class Edit_IssueServiceModel : Issue
    {

    }
    public class Delete_IssueServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
        public int? delete { get; set; }

    }

    public class FindOne_IssueServiceModel : WhereModel
    {
    }

    public class Count_IssueServiceModel : WhereModel
    {
    }

}
