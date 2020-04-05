using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.Domain.Models;
using CTIN.WebApi.Bases.Swagger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.User;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_UserModel : Search_UserServiceModel
    {
    }

    public class Add_UserModel
    {
        public int? point { get; set; }
        public List<userfilmleanningDataJsonModel> filmleanning { get; set; }
        public informationDataJsonModel information { get; set; }
        public List<int> listfrendid { get; set; }
        public Add_UserModel_DataDbJson dataDb { get; set; }
    }

    public class informationDataJsonModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }

    public class userfilmleanningDataJsonModel
    {
        public int filmid { get; set; }
        public int sttWord { get; set; }
        public List<wordleanedDataJsonModel> wordleaned { get; set; }
    }

    public class wordleanedDataJsonModel
    {
        public int stt { get; set; }
        public DateTime time { get; set; }
        public int check { get; set; }
        public int classic { get; set; }
    }

    public class Add_UserModel_DataDbJson
    {
        public int status { get; set; }
    }

    public class Edit_UserModel : Add_UserModel
    {
    }

    public class FindOne_UserModel : FindOne_UserServiceModel
    {

    }

    public class Count_UserModel : Count_UserServiceModel
    {

    }


}
