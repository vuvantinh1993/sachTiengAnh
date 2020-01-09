using CTIN.Common.Models;

namespace CTIN.DataAccess.Models
{

    public partial class BizModel
    {
        public int id { get; set; }
        public BizModelDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }

        public class BizModelDataJson
        {
            public virtual string BizModeNameVn { get; set; }
            public virtual string BizModeNameEn { get; set; }
            public virtual string BizModeCode { get; set; }
            public virtual string note { get; set; }
            public virtual int IdPart { get; set; }
        }
    }

}
