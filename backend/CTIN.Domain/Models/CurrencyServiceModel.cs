using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CTIN.Domain.Models
{
    public class Search_CurrencyServiceModel : SearchModel
    {
        public Search_CurrencyServiceModel()
        {
            order = "[{\"iso\": false}]";
            size = 200;
        }
    }
}
