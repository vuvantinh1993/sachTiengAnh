using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ModeBiddingServiceModel : SearchModel
    {

    }

    public class Add_ModeBiddingServiceModel : ModeBidding
    {

    }

    public class Edit_ModeBiddingServiceModel : ModeBidding
    {

    }

    public class Delete_ModeBiddingServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ModeBiddingServiceModel : WhereModel
    {
    }

    public class Count_ModeBiddingServiceModel : WhereModel
    {
    }
}
