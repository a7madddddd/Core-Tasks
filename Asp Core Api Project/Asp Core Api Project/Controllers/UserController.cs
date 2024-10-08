﻿using Asp_Core_Api_Project.DTOs;
using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly ILogger<UserController> _logger;
        private readonly TokenGenerator _tokenGenerator;


        public UserController(MyDbContext db, ILogger<UserController> logger, TokenGenerator tokenGenerator)
        {
            _db = db;
            _logger = logger;
            _tokenGenerator = tokenGenerator;
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


        [HttpPost("Register")]
        public IActionResult UserRequest([FromForm] userRequestDOT Users)
        {
            byte[] hash, salt;
            passwrdHash.CreatePasswordHash(Users.UsPas, out hash, out salt);
            
            
            var data = new User
            {
                 
                UsName = Users.UsName,
                UsPas = Users.UsPas,
                UsEm = Users.UsEm,
                PasswordSalt= salt,
                PasswordHash = hash
            };

            var imagesFolderUSer = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (Directory.Exists(imagesFolderUSer))
            {

                Directory.CreateDirectory(imagesFolderUSer);
            }
            var userRole = new UserRole
            {

                UserId = data.UsId,
                Role = "Admin"
            };
            _db.Users.Add(data);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm] userRequestDOT user)
        {
            var potato = _db.Users.FirstOrDefault(u => u.UsEm == user.UsEm);
            if (potato == null || !passwrdHash.VerifyPasswordHash(user.UsPas, potato.PasswordHash, potato.PasswordSalt))
            {
                return Unauthorized("bad!!!");
            }


            var Roles = _db.UserRoles.Where(x => x.UserId == potato.UsId).Select(x => x.Role).ToList();

            // Use a fallback value for UsName if it's null or empty
            string userName = string.IsNullOrEmpty(user.UsName) ? "Guest" : user.UsName;

            var token = _tokenGenerator.GenerateToken(userName, Roles);

            return Ok(new { Token = token });



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
