using CTIN.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CTIN.WebApi.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected string GetDomain()
        {
            return $"{Request.Scheme}://{Request.Host}";
        }

        protected string GetLanguage()
        {
            var key = "vi";
            if (Request.Headers.ContainsKey("Language"))
            {
                key = Request.Headers["Language"];
            }
            return key;
        }

        protected int GetUserId()
        {
            //var claim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            //return claim != null ? long.Parse(claim.Value) : 0;
            return 0;
        }

        protected async Task<IActionResult> BindData(dynamic data = null, List<ErrorModel> errors = null, PagingModel paging = null)
        {
            if (errors != null)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError(item.key, item.value);
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultModel<dynamic>
                {
                    error = new SerializableError(ModelState),
                    data = data,//todo remve
                    paging = paging
                });
            }

            if (paging != null)
            {
                return Ok(new ResultModel<dynamic>
                {
                    data = data,
                    paging = paging
                });
            }
            return Ok(data);
        }
    }
}
