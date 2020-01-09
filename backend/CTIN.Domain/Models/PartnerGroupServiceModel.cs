using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
 
    public class Search_PartnerGroupServiceModel : SearchModel
    {

    }

    public class Add_PartnerGroupServiceModel : PartnerGroup
    {

    }

    public class Edit_PartnerGroupServiceModel : PartnerGroup
    {

    }

    public class Delete_PartnerGroupServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_PartnerGroupServiceModel : WhereModel
    {
    }

    public class Count_PartnerGroupServiceModel : WhereModel
    {
    }
}
