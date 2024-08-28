using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost]
        public IActionResult result(int n1, int n2)
        {

            if (n1 == 30 || n2 == 30)
            {
                return Ok("true");
            }
            else if (n1 + n2 == 30)
            {
                return Ok("true");
            }

            return BadRequest();
        }

    }
}
