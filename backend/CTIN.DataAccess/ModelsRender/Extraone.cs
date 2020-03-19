using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Extraone
    {
        public int Id { get; set; }
        public string TextEn { get; set; }
        public int? Categoryfilmid { get; set; }
        public string Doubtid { get; set; }
        public string Unselectid { get; set; }
        public string DataDb { get; set; }
        public string Urlaudio { get; set; }
        public byte[] Audio { get; set; }
        public string TextVn { get; set; }
        public string Fullname { get; set; }
        public string AnswerWrongEn { get; set; }
        public string AnswerWrongVn { get; set; }
    }
}
