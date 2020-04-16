using CTIN.WebApi.Bases.Swagger;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static CTIN.Domain.Models.FilesServiceModel;

namespace CTIN.WebApi.Modules.System.Models
{
    public class FileModel
    {
        public class Search_FileModel : Search_FilesServiceModel
        {
        }

        public class Add_FileModel : Add_FilesServiceModel
        {

        }

        public class FindOne_FileModel : FindOne_FilesServiceModel
        {

        }

        public class Count_FileModel : Count_FilesServiceModel
        {

        }
    }
}
