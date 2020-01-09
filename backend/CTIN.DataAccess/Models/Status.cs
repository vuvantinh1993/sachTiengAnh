using CTIN.Common.Models;
namespace CTIN.DataAccess.Models
{
    public partial class Status
    {
        public int id { get; set; }
        public StatusDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class StatusDataJson
        {
            public virtual string statusName { get; set; }
            public virtual string note { get; set; }
            public virtual int statusType { get; set; }
        }
    }
}