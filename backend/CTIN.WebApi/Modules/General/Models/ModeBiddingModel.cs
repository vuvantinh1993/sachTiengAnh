using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CTIN.DataAccess.Models.ModeBidding;

namespace CTIN.WebApi.Modules.General.Models
{
 
    public class Search_ModeBiddingModel : Search_ModeBiddingServiceModel
    {
    }

    public class Add_ModeBiddingModel : ModeBidding
    {

    }

    public class Edit_ModeBiddingModel : Add_ModeBiddingModel
    {


    }

    public class FindOne_ModeBiddingModel : FindOne_ModeBiddingServiceModel
    {

    }

    public class Count_ModeBiddingModel : Count_ModeBiddingServiceModel
    {

    }
}
