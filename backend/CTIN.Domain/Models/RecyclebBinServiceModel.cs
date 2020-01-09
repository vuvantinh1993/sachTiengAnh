using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_RecyclebBinServiceModel : SearchModel
    {

    }
    public class Delete_RecyclebBinServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }
    public class Restore_RecyclebBinServiceModel
    {
        public virtual int id { get; set; }
    }
    public class FindOne_RecyclebBinServiceModel : WhereModel
    {
    }

    public class Count_RecyclebBinServiceModel : WhereModel
    {
    }

}
