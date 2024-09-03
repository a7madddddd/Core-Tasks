using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Math(string nums)
        { var count = 0;
            foreach (int i in nums) {

                if (i % 2 != 0) {
                    count++;
                    return Ok(nums + '=' +count);
                }
            }
            return BadRequest();
        }
    }
}
