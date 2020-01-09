using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_PartnerServiceModel : SearchModel
    {

    }

    public class Add_PartnerServiceModel : Partner
    {

    }

    public class Edit_PartnerServiceModel : Partner
    {

    }

    public class Delete_PartnerServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_PartnerServiceModel : WhereModel
    {
    }

    public class Count_PartnerServiceModel : WhereModel
    {
    }
}
