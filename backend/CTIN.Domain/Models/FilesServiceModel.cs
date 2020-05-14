using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class FilesServiceModel
    {
        public class Search_FilesServiceModel : SearchModel
        {

        }

        public class Add_FilesServiceModel
        {
            public virtual string folder { get; set; } // null is save to db

            public virtual List<IFormFile> file { get; set; }

            public virtual int width { get; set; }

            public virtual int height { get; set; }

            public virtual int quantity { get; set; }

            public virtual string domail { get; set; }

            public virtual string creationBy { get; set; }

            public virtual DateTime creationTime { get; set; }
        }

        public class Delete_FilesServiceModel
        {
            public virtual long id { get; set; }

            public virtual string delectationBy { get; set; }

            public virtual DateTime delectationTime { get; set; }
        }

        public class FindOne_FilesServiceModel : WhereModel
        {
        }

        public class Count_FilesServiceModel : WhereModel
        {
        }
    }
}
