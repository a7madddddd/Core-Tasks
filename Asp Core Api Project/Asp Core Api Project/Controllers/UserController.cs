using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Core_Api_Project.Controllers
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

        public IActionResult getAllUsers() {

            var AllUsers = _db.Users.ToList();
            return Ok(AllUsers);
        }

        [HttpGet]
        [Route("Api/User/{id}")]

        public IActionResult UserByID(int id)
        {

            if (id == 0)
            {
                return NoContent();
            };

            var UserById = _db.Users.Find(id);

            return Ok(UserById);

        }

        [HttpGet("{name}")]
        public IActionResult UserByName(string name)
        {
            if (name == null)
            {
                return NotFound();
            }
            var UserByName = _db.Users.Where(u => u.UsName == name).FirstOrDefault();
            return BadRequest(UserByName);
        }


        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id) {

            if (id == 0) {
            
                return NoContent();
            }

            var deleteuserById = _db.Users.Find(id);

            _db.Users.Remove(deleteuserById);
            _db.SaveChanges();
            return NoContent();
        }
        
    }
}
