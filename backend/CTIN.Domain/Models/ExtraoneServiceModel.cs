using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ExtraoneServiceModel : SearchModel
    {

    }

    public class Add_ExtraoneServiceModel
    {
        public IFormFile audioquestion { get; set; }
        public string textquestion { get; set; }
        public IFormFile audioanswer { get; set; }
        public string textanswer { get; set; }
        public int categoryfilmid { get; set; }
        public List<int> doubtid { get; set; }
        public List<int> unselectid { get; set; }
        public Add_ExtraoneModel_DataDbJson dataDb { get; set; }
        public class Add_ExtraoneModel_DataDbJson
        {
            public int status { get; set; }
            public virtual DateTime createdDate { get; set; } = DateTime.Now;
            public virtual long createdBy { get; set; }
        }

        public string domain { get; set; }

    }

    public class Edit_ExtraoneServiceModel : Extraone
    {

    }

    public class Delete_ExtraoneServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_ExtraoneServiceModel : WhereModel
    {
    }

    public class Count_ExtraoneServiceModel : WhereModel
    {
    }

}
