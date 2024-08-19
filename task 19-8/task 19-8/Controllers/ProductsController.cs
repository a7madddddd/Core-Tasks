using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_19_8.Models;

namespace task_19_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db) { 
        
            _db = db;
        }
        [HttpGet]

        public IActionResult getAllProducts() {
            var allProducts = _db.Products.ToList();
            return Ok(allProducts);
        }
        [HttpGet("id")]
        public IActionResult getProducts(int? id) {


            var oneProducts = _db.Products.Where(p => p.PId == id);       
            return Ok(oneProducts);
        }



    }
}
