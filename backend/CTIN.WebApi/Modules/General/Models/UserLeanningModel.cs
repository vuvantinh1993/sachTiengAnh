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

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_UserLeanningModel : Search_UserLeanningServiceModel
    {
        //public Search_UserLeanningModel()
        //{
        //    order = "[{\"id\": true}]";
        //}
        //public override string order { get => base.order; set => base.order = value; }
    }

    public class Updatepoint_UserLeanningModel : Updatepoint_UserLeanningServiceModel
    {

    }

    public class Add_UserLeanningModel
    {
        public int? point { get; set; }
        public List<userfilmleanningDataJsonModel> filmleanning { get; set; }
        public informationDataJsonModel information { get; set; }
        public List<int> listfrendid { get; set; }
        public Add_UserLeanningModel_DataDbJson dataDb { get; set; }
    }

    public class informationDataJsonModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string image { get; set; }
        public string address { get; set; }
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
        public int isforget { get; set; } // nếu là 0 có nghãi chưa quên, nếu là 1 có nghĩa đã quên
    }

    public class Add_UserLeanningModel_DataDbJson
    {
        public int status { get; set; }
    }

    public class Edit_UserLeanningModel : Add_UserLeanningModel
    {
    }

    public class FindOne_UserLeanningModel : FindOne_UserLeanningServiceModel
    {

    }

    public class Count_UserLeanningModel : Count_UserLeanningServiceModel
    {

    }

    public class LoginModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
    }

}
