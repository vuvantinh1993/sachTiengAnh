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
    public class Search_WordFilmServiceModel : SearchModel
    {

    }

    public class Add_WordFilmServiceModel
    {
        public IFormFile audio { get; set; }
        public string textVn { get; set; }
        public string textEn { get; set; }
        public string fullName { get; set; }
        public Add_WordFilmModel_DataDbJson dataDb { get; set; }
        public string domain { get; set; }
        public int? size { get; set; }
        public int? stt { get; set; }

    }

    public class Add_WordFilmModel_DataDbJson
    {
        public int status { get; set; }
        public virtual DateTime createdDate { get; set; } = DateTime.Now;
        public virtual string createdBy { get; set; }
    }

    public class Edit_WordFilmServiceModel : WordFilm
    {

    }

    public class Delete_WordFilmServiceModel
    {
        public virtual int id { get; set; }
        public virtual string delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_WordFilmServiceModel : WhereModel
    {
    }

    public class Count_WordFilmServiceModel : WhereModel
    {
    }

}
