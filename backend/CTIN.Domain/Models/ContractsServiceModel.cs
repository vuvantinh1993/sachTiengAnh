using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ContractsServiceModel : SearchModel
    {

    }

    public class Add_ContractsServiceModel : Contracts
    {

    }

    public class Edit_ContractsServiceModel : Contracts
    {

    }

    public class Delete_ContractsServiceModel
    {
        public virtual int id { get; set; }
        public virtual int userId { get; set; }
        public virtual int? delete { get; set; }

    }

    public class FindOne_ContractsServiceModel : WhereModel
    {
    }

    public class Count_ContractsServiceModel : WhereModel
    {
    }

}
