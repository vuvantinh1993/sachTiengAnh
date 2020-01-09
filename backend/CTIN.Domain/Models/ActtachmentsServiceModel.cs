using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ActtachmentsServiceModel : SearchModel
    {

    }

    public class Add_ActtachmentsServiceModel : Acttachments
    {

    }

    public class Edit_ActtachmentsServiceModel : Acttachments
    {

    }

    public class Delete_ActtachmentsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_ActtachmentsServiceModel : WhereModel
    {
    }

    public class Count_ActtachmentsServiceModel : WhereModel
    {
    }

}
