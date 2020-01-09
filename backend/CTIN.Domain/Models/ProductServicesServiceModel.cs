using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_ProductServicesServiceModel : SearchModel
    {

    }

    public class Add_ProductServicesServiceModel : ProductServices
    {

    }

    public class Edit_ProductServicesServiceModel : ProductServices
    {

    }

    public class Delete_ProductServicesServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ProductServicesServiceModel : WhereModel
    {
    }

    public class Count_ProductServicesServiceModel : WhereModel
    {
    }
}
