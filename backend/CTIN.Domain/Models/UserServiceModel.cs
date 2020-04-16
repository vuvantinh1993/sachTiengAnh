using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_UserServiceModel : SearchModel
    {

    }

    public class Updatepoint_UserServiceModel
    {
        public int stt1 { get; set; }
        public int check1 { get; set; }
        public int classic1 { get; set; }
        public int? stt2 { get; set; }
        public int? check2 { get; set; }
        public int? classic2 { get; set; }
        public string chuoimahoa { get; set; }
    }

    public class OneWordUpate_UserServiceModel
    {
        public int? stt { get; set; }
        public int? check { get; set; }
        public int? classic { get; set; }
    }

    public class Add_UserServiceModel : User
    {

    }

    public class Edit_UserServiceModel : User
    {

    }

    public class Delete_UserServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_UserServiceModel : WhereModel
    {
    }

    public class Count_UserServiceModel : WhereModel
    {
    }

}
