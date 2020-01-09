using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Position
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string DataDb { get; set; }
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public int? PositionTypeId { get; set; }
        public int? WorkId { get; set; }
        public string Description { get; set; }
        public int? OrderIndex { get; set; }
        public bool? AllowDisplay { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual PositionType PositionType { get; set; }
    }
}
