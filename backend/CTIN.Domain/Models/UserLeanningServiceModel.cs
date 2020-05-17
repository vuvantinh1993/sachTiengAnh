using CTIN.Common.Enums;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_UserLeanningServiceModel : SearchModel
    {

    }

    public class Updatepoint_UserLeanningServiceModel
    {
        public string chuoimahoa { get; set; }
        public List<OneWordUpate_UserLeanningServiceModel> wordRelearn { get; set; }
    }

    public class OneWordUpate_UserLeanningServiceModel
    {
        //public int stt { get; set; }
        public int check { get; set; }
        public ClassicWordEnum classic { get; set; }
        public int idWord { get; set; }
        public int idFilm { get; set; }
    }

    public class Add_UserLeanningServiceModel : UserLeanning
    {

    }

    public class Edit_UserLeanningServiceModel : UserLeanning
    {

    }

    public class Delete_UserLeanningServiceModel
    {
        public virtual int id { get; set; }
        public virtual string delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_UserLeanningServiceModel : WhereModel
    {
    }

    public class Count_UserLeanningServiceModel : WhereModel
    {
    }

}
