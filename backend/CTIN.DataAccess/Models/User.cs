using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public List<UserfilmleanningDataJson> filmleanning { get; set; }
        public int? point { get; set; }
        public List<int> listfrendid { get; set; }
        public DataDbJson dataDb { get; set; }
    }

    public class UserfilmleanningDataJson
    {
        public string namefilm { get; set; }
        public int positionword { get; set; }
    }
}
