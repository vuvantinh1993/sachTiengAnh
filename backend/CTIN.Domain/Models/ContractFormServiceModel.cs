using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ContractFormServiceModel : SearchModel
    {

    }

    public class Add_ContractFormServiceModel : ContractForm
    {

    }

    public class Edit_ContractFormServiceModel : ContractForm
    {

    }

    public class Delete_ContractFormServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ContractFormServiceModel : WhereModel
    {
    }

    public class Count_ContractFormServiceModel : WhereModel
    {
    }

}
