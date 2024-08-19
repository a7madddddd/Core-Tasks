using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db) {
            _db = db;
        }
        [HttpGet]
        public IActionResult getAllCategories() {
        
            var categories = _db.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet("id")]
        public IActionResult getCategories( int? id) {  
            var oneProduct = _db.Categories.FirstOrDefault(b => b.CId == id);
            return Ok(oneProduct);
        }



        //[HttpGet("id")]
        //public IActionResult getCategory(int id) {
        //    var category = _db.Categories.FirstOrDefault(c => c.CId == id);
        //    return Ok(category);
        //}



        //[HttpGet("id")]
        //public IActionResult allCategorys(int id) { 
        //    var categories = _db.Categories.Find(id);
        //            return Ok(categories);
        //}
    }
}
