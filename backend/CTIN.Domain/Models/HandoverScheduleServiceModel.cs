using CTIN.Common.Models;
using CTIN.DataAccess.Models;
namespace CTIN.Domain.Models
{
    public class Search_HandoverScheduleServiceModel : SearchModel
    {

    }

    public class Add_HandoverScheduleServiceModel : HandoverSchedule
    {

    }

    public class Edit_HandoverScheduleServiceModel : HandoverSchedule
    {

    }

    public class Delete_HandoverScheduleServiceModel
    {
        public virtual int id { get; set; }
        public int? delete { get; set; }

    }

    public class FindOne_HandoverScheduleServiceModel : WhereModel
    {
    }

    public class Count_HandoverScheduleServiceModel : WhereModel
    {
    }

}
