using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TargetDetail
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string TargetDetailNameVn { get; set; }
        public string TargetDetailNameEn { get; set; }
        public int? StagePercent { get; set; }
        public int? Idtarget { get; set; }
        public int? StageIndex { get; set; }
        public string StageColor { get; set; }
        public string Note { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
