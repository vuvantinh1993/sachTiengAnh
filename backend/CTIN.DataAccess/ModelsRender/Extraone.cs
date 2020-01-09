using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Extraone
    {
        public int Id { get; set; }
        public string Audioquestion { get; set; }
        public string Textquestion { get; set; }
        public string Audioanswer { get; set; }
        public string Textanswer { get; set; }
        public int Categoryfilmid { get; set; }
        public string Doubtid { get; set; }
        public string Unselectid { get; set; }
        public string DataDb { get; set; }
    }
}
