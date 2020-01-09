using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using CTIN.WebApi.Bases.Swagger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.RecyclebBin;

namespace CTIN.WebApi.Modules.General.Models
{
    public class Search_RecyclebBinModel : Search_RecyclebBinServiceModel
    {
    }

    public class FindOne_RecyclebBinModel : FindOne_RecyclebBinServiceModel
    {

    }

    public class Count_RecyclebBinModel : Count_RecyclebBinServiceModel
    {

    }
}
