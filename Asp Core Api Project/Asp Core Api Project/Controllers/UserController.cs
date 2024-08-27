using Asp_Core_Api_Project.DTOs;
using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public IActionResult getAllUsers()
        {

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
        public IActionResult deleteUser(int id)
        {

            if (id == 0)
            {

                return NoContent();
            }

            var deleteuserById = _db.Users.Find(id);

            _db.Users.Remove(deleteuserById);
            _db.SaveChanges();
            return NoContent();
        }



        [HttpPost]
        public IActionResult UserRequest([FromForm] userRequestDOT Users)
        {
            var data = new User
            {
                UsName = Users.UsName,
                UsPas = Users.UsPas,
            };

            var imagesFolderUSer = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (Directory.Exists(imagesFolderUSer))
            {

                Directory.CreateDirectory(imagesFolderUSer);
            }

            _db.Users.Add(data);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult PutUserResponse([FromForm] userRequestDOT Users, int id)
        {
           
            var user = _db.Users.FirstOrDefault(u => u.UsId == id);
            if (user == null)
            {
                return NotFound(); 
            }

            // Update user details
            user.UsName = Users.UsName;
            user.UsPas = Users.UsPas;

            _db.Users.Update(user);
            _db.SaveChangesAsync(); 

            return Ok();
        }


    }
}
