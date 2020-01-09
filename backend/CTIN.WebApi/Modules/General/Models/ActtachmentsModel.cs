using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Models;
using CTIN.DataAccess.Contexts;
using CTIN.Domain.Models;
using CTIN.WebApi.Bases.Swagger;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static CTIN.DataAccess.Models.Acttachments;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_ActtachmentsModel : Search_ActtachmentsServiceModel
    {
    }

    public class Add_ActtachmentsModel
    {

        public Add_ActtachmentsModel_DataJson fileData { get; set; }
        public Add_ActtachmentsModel_DataDbJson dataDb { get; set; }

        public class Add_ActtachmentsModel_DataJson : ActtachmentsfileDataJson
        {

        }

        public class Add_ActtachmentsModel_DataDbJson
        {
            public int status { get; set; }
        }
    }

    public class Edit_ActtachmentsModel : Add_ActtachmentsModel
    {
    }

    public class FindOne_ActtachmentsModel : FindOne_ActtachmentsServiceModel
    {

    }

    public class Count_ActtachmentsModel : Count_ActtachmentsServiceModel
    {

    }
}
