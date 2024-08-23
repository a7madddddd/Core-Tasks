//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using task_19_8.Models;

//namespace task_19_8.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoriesController : ControllerBase
//    {
//        private readonly MyDbContext _db;

//        public CategoriesController(MyDbContext db)
//        {
//            _db = db;
//        }

//        [HttpGet]
//        public IActionResult GetAllCategories()
//        {
//            var categories = _db.Categories.ToList();
//            return Ok(categories);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetCategoryById(int? id)
//        {
//            if (id == null)
//            {
//                return BadRequest("Category ID is required.");
//            }

//            var category = _db.Categories.FirstOrDefault(b => b.CId == id);

//            if (category == null)
//            {
//                return NotFound();
//            }

//            return Ok(category);
//        }

//        [HttpGet("name/{name}")]
//        public IActionResult GetCategoryByName(string name)
//        {
//            var category = _db.Categories.FirstOrDefault(b => b.CName == name);

//            if (category == null)
//            {
//                return NotFound();
//            }

//            return Ok(category);
//        }



//        [HttpDelete("{id}")]
//        public IActionResult DeleteCategory(int id)
//        {
//            var category = _db.Categories.FirstOrDefault(b => b.CId == id);
//            if (category == null)
//            {
//                return NotFound();
//            }

//            _db.Categories.Remove(category);
//            _db.SaveChanges();

//            return NoContent();


//        }
//    }
//}




