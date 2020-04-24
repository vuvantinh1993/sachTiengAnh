using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    [Table("Wordfilm")]
    public partial class Extraone
    {
        public int id { get; set; }
        public byte[] audio { get; set; }
        public string textVn { get; set; }
        public string fullName { get; set; }
        public string textEn { get; set; }
        public string urlaudio { get; set; }
        public string answerWrongEn { get; set; }
        public string answerWrongVn { get; set; }
        public List<int> doubtid { get; set; }
        public List<int> unselectid { get; set; }
        public DataDbJson dataDb { get; set; }
        public long? size { get; set; }
        public int stt { get; set; }
        public int categoryfilmid { get; set; }

        public Categoryfilm categoryfilm { get; set; }
    }
}
