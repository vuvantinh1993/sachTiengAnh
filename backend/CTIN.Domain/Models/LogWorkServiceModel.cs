using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class 
        Search_LogWorkServiceModel : SearchModel
    {

    }

    public class Add_LogWorkServiceModel : LogWork
    {

    }

    public class Edit_LogWorkServiceModel : LogWork
    {

    }

    public class Delete_LogWorkServiceModel
    {
        public virtual int id { get; set; }
       
    }

    public class FindOne_LogWorkServiceModel : WhereModel
    {
    }

    public class Count_LogWorkServiceModel : WhereModel
    {
    }

}
