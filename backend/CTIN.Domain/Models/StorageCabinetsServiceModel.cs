using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{

    public class Search_StorageCabinetsServiceModel : SearchModel
    {

    }

    public class Add_StorageCabinetsServiceModel : StorageCabinets
    {

    }

    public class Edit_StorageCabinetsServiceModel : StorageCabinets
    {

    }

    public class Delete_StorageCabinetsServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_StorageCabinetsServiceModel : WhereModel
    {
    }

    public class Count_StorageCabinetsServiceModel : WhereModel
    {
    }
}
