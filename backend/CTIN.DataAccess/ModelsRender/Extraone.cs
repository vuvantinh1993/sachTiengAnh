using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Extraone
    {
        public int Id { get; set; }
        public string Textquestion { get; set; }
        public string Textanswer { get; set; }
        public int? Categoryfilmid { get; set; }
        public string Doubtid { get; set; }
        public string Unselectid { get; set; }
        public string DataDb { get; set; }
        public string Urlaudioanswer { get; set; }
        public string Urlaudioquestion { get; set; }
        public byte[] Audioquestion { get; set; }
        public byte[] Audioanswer { get; set; }
    }
}
