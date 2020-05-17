using CTIN.Common.Enums;
using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    [Table("userLeanning")]
    public partial class UserLeanning
    {
        public int id { get; set; }
        public string userId { get; set; }
        public ApplicationUser user { get; set; }
        public int point { get; set; }
        public List<filmlearnedJson> listFilmLearned { get; set; }
        public List<wordleanedJson> filmLearnning { get; set; }
        public List<wordleanedJson> filmForgeted { get; set; }
        public List<wordleanedJson> filmPunishing { get; set; }
        public List<wordleanedJson> filmFinish { get; set; }
        public List<wordleanedJson> filmFinishForget { get; set; }
    }

    public class filmlearnedJson
    {
        public int filmid { get; set; }
        public int sttWord { get; set; }
        public bool isFinish { get; set; }
        public double speedVideo { get; set; }
    }

    public class wordleanedJson
    {
        public int idfilm { get; set; }
        public int idWord { get; set; }
        public DateTime time { get; set; }
        public ForgetEnum isforget { get; set; } // nếu là 0 có nghãi chưa quên, nếu là 1 có nghĩa đã quên
        public int check { get; set; } // là từ đã học được mấy lần rồi ban đầu sẽ là 1 lần (là số lần từ đó được học)
        public ClassicWordEnum classic { get; set; } // là thuộc loại nào trong 5 loại học đúng hạn hay sai hạn
    }
}
