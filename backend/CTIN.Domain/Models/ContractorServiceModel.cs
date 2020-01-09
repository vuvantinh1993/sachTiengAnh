using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{


    public class Search_ContractorServiceModel : SearchModel
    {

    }

    public class Add_ContractorServiceModel : Contractor
    {

    }

    public class Edit_ContractorServiceModel : Contractor
    {

    }

    public class Delete_ContractorServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ContractorServiceModel : WhereModel
    {
    }

    public class Count_ContractorServiceModel : WhereModel
    {
    }
}
