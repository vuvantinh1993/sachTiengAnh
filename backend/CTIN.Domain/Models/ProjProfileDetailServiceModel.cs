using CTIN.Common.Models;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_ProjProfileDetailServiceModel : SearchModel
    {

    }

    public class Add_ProjProfileDetailServiceModel : ProjProfileDetail
    {

    }

    public class Edit_ProjProfileDetailServiceModel : ProjProfileDetail
    {

    }

    public class Delete_ProjProfileDetailServiceModel
    {
        public virtual int id { get; set; }
        public virtual long delectationBy { get; set; }
        public virtual DateTime delectationTime { get; set; }

    }

    public class FindOne_ProjProfileDetailServiceModel : WhereModel
    {
    }

    public class Count_ProjProfileDetailServiceModel : WhereModel
    {
    }
}
