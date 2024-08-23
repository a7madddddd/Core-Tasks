using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db)
        {

            _db = db;
        }


        [HttpGet]

        public ActionResult GetAllProduct()
        {

            var AllProducts = _db.Products.ToList();
            return Ok(AllProducts);
        }


        [HttpGet]
        [Route("Api/product/{id}")]

        public ActionResult GetProductById(int id)
        {

            if (id > 0)
            {

                var ProductById = _db.Products.SingleOrDefault(c => c.PId == id);
                return Ok(ProductById);
            }

            return NotFound();
        }


        [HttpGet("name")]
        public ActionResult GetName(string name)
        {

            if (name != null)
            {

                var productByName = _db.Products.Where(p => p.PName == name);

                return Ok(name);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]


        public IActionResult DeleteProduct(int id)
        {


            if (id == 0)
            {

                return NotFound();

            }
            var deleteproduct = _db.Products.Where(p => p.PId == id).FirstOrDefault();

            _db.Remove(deleteproduct);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
