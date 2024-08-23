using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _db;

        public UserController(MyDbContext db)
        {
            _db = db;

        }

        [HttpGet]
        [Route("Api/User/{id}")]

        public IActionResult UserByID(int id) {

            if (id == 0) { 

                return NoContent();
            };
            return Ok();



        }
    }
}


