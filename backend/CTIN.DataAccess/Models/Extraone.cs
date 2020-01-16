using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class Extraone
    {
        public int id { get; set; }
        public byte[] audioquestion { get; set; }
        public string textquestion { get; set; }
        public byte[] audioanswer { get; set; }
        public string textanswer { get; set; }
        public int categoryfilmid { get; set; }
        public string urlaudioanswer { get; set; }
        public string urlaudioquestion { get; set; }
        public List<int> doubtid { get; set; }
        public List<int> unselectid { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
