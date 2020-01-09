using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_BiddingDocumentsServiceModel : SearchModel
    {

    }

    public class Add_BiddingDocumentsServiceModel : BiddingDocuments
    {

    }

    public class Edit_BiddingDocumentsServiceModel : BiddingDocuments
    {

    }

    public class Delete_BiddingDocumentsServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
    }

    public class FindOne_BiddingDocumentsServiceModel : WhereModel
    {
    }

    public class Count_BiddingDocumentsServiceModel : WhereModel
    {
    }

}
