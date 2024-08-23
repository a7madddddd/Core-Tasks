using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db)
        {

            _db = db;
        }

        [HttpGet]
        [Route("Api/categories")]
        public IActionResult AllCategories()
        {

            var AllCategories = _db.Categories.ToList();

            return Ok(AllCategories);
        }


        // Rout Attrebute
        [HttpGet("Api/Category/{id}")]

        public IActionResult CategoriesById(int? id)
        {

            if (id == null && id > 3)
            {
                return BadRequest();
            }

            else if (id != null)
            {

                var productById = _db.Categories.Where(c => c.CId == id).FirstOrDefault();

                return Ok(productById);
            }

            return BadRequest();

        }



        [HttpGet]
        [Route("Api/Categories/name/{name}")]


        public IActionResult CategoryByName(string name)
        {

            if (name == null)
            {

                return NotFound();
            }
            else if (name != null)
            {

                var CategoriesByName = _db.Categories.Where(c => c.CName == name).ToList();
                return Ok(CategoriesByName);

            }
            return Ok();
        }
        [HttpDelete("Api/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleteCategory = _db.Categories.FirstOrDefault(c => c.CId == id);


            if (id < 1)
            {

                return NotFound();
            }

            _db.Remove(deleteCategory);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
    