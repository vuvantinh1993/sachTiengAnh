using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_TemplateServiceModel: SearchModel
    { 
    
    }

    public class Add_TemplateServiceModel: Template
    {

    }

    public class Edit_TemplateServiceModel: Template
    {
       
    }

    public class Delete_TemplateServiceModel
    {
        public virtual Guid id { get; set; }

        public virtual long delectationBy { get; set; }

        public virtual DateTime delectationTime { get; set; }
    }

    public class FindOne_TemplateServiceModel : WhereModel
    {
    }

    public class Count_TemplateServiceModel: WhereModel
    {      
    }

}
