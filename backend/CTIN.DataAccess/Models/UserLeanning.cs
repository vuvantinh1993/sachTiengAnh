using CTIN.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CTIN.DataAccess.Models
{
    [Table("UserLeanning")]
    public partial class UserLeanning
    {
        public int id { get; set; }
        public string userId { get; set; }
        public ApplicationUser user { get; set; }
        public int point { get; set; }
        public List<userfilmleanningDataJson> filmleanning { get; set; }
        public List<userfilmleanningDataJson> filmforgeted { get; set; }
        public List<userfilmleanningDataJson> filmpunishing { get; set; }
        public List<userfilmleanningDataJson> filmfinish { get; set; }
        public List<int> listfrendid { get; set; }
        public int rankId { get; set; }
        public int star { get; set; }
        public DataDbJson dataDb { get; set; }
        public Rank rank { get; set; }
    }

    public class userfilmleanningDataJson
    {
        public int filmid { get; set; }
        public int sttWord { get; set; }
        public List<wordleanedDataJson> wordleaned { get; set; }
    }

    public class wordleanedDataJson
    {
        public int stt { get; set; }
        public DateTime time { get; set; }
        public int isforget { get; set; } // nếu là 0 có nghãi chưa quên, nếu là 1 có nghĩa đã quên
        public int check { get; set; } // là từ đã học được mấy lần rồi ban đầu sẽ là 1 lần (là số lần từ đó được học)
        public int classic { get; set; } // là thuộc loại nào trong 5 loại học đúng hạn hay sai hạn
    }

}
