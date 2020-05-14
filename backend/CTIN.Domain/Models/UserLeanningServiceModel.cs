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
        public int stt1 { get; set; }
        public int check1 { get; set; }
        public int classic1 { get; set; }
        public int? stt2 { get; set; }
        public int? check2 { get; set; }
        public int? classic2 { get; set; }
        public int? stt3 { get; set; }
        public int? check3 { get; set; }
        public int? classic3 { get; set; }
        public int? stt4 { get; set; }
        public int? check4 { get; set; }
        public int? classic4 { get; set; }
        public string chuoimahoa { get; set; }
    }

    public class OneWordUpate_UserLeanningServiceModel
    {
        public int? stt { get; set; }
        public int? check { get; set; }
        public int? classic { get; set; }
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
