using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Logworks
    {
        public int Id { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int EmpId { get; set; }
        public string Content { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
