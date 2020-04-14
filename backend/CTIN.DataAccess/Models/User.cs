using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class User
    {
        public int id { get; set; }
        public int? point { get; set; }
        public List<userfilmleanningDataJson> filmleanning { get; set; }
        public List<userfilmleanningDataJson> filmforgeted { get; set; }
        public List<userfilmleanningDataJson> filmpunishing { get; set; }
        public List<userfilmleanningDataJson> filmfinish { get; set; }
        public informationDataJson information { get; set; }
        public List<int> listfrendid { get; set; }
        public DataDbJson dataDb { get; set; }
    }

    public class informationDataJson
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string image { get; set; }
        public string address { get; set; }
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
