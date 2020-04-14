using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Categoryfilm
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public string DataDb { get; set; }
        public byte Pointword { get; set; }
        public string Discription { get; set; }
        public int? TotalWord { get; set; }
        public string LinkImg { get; set; }
        public int TotalUser { get; set; }
    }
}
