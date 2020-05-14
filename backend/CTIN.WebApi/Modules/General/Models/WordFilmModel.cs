using CTIN.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace CTIN.WebApi.Modules.General.Models
{

    public class Search_WordFilmModel : Search_WordFilmServiceModel
    {
    }

    public class Add_WordFilmModelaaaa
    {
        public IFormFile audio { get; set; }
    }

    public class Add_WordFilmModel : Add_WordFilmServiceModel
    {

    }

    public class Edit_WordFilmModel : Add_WordFilmModel
    {
    }

    public class FindOne_WordFilmModel : FindOne_WordFilmServiceModel
    {

    }

    public class Count_WordFilmModel : Count_WordFilmServiceModel
    {

    }
}
