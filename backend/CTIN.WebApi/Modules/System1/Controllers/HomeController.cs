using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CTIN.WebApi.Modules.System.Controlles
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Path.StartsWithSegments("/admin"))
            {
                return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "index.html"), "text/HTML");
            }
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "main", "index.html"), "text/HTML");
        }
    }
}