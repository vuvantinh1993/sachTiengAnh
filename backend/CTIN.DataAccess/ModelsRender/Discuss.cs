using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Discuss
    {
        public int Id { get; set; }
        public int ProjworkId { get; set; }
        public string Topic { get; set; }
        public string PeopleInvolved { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public bool? AllowDisplay { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
