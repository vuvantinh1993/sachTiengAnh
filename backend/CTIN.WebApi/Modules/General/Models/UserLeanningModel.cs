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
        public int point { get; set; }
        public List<filmlearnedJsonModel> listFilmLearned { get; set; }
        public List<wordleanedJsonModel> filmLearnning { get; set; }
    }

    public class filmlearnedJsonModel
    {
        public int filmid { get; set; }
        public int sttWord { get; set; }
        public bool isFinish { get; set; }
        public double speedVideo { get; set; }
    }

    public class wordleanedJsonModel
    {
        public int idfilm { get; set; }
        public int stt { get; set; }
        public DateTime time { get; set; }
        public ForgetEnum isforget { get; set; } // nếu là 0 có nghãi chưa quên, nếu là 1 có nghĩa đã quên
        public int check { get; set; } // là từ đã học được mấy lần rồi ban đầu sẽ là 1 lần (là số lần từ đó được học)
        public ClassicWordEnum classic { get; set; } // là thuộc loại nào trong 5 loại học đúng hạn hay sai hạn
    }

    public class Add_UserLeanningModel_DataDbJson
    {
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
}
