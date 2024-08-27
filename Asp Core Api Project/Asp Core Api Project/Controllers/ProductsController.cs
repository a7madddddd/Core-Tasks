using Asp_Core_Api_Project.DTOs;
using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet]
        [Route("Api/productByCategoryId/{id}")]
        public ActionResult GetProductByCategoryId(int id)
        {

            if (id > 0)
            {

                var ProductById = _db.Products.SingleOrDefault(c => c.CId == id);
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


        [HttpPost]
        public IActionResult PostProduct([FromForm] postProducts product)
        {

            var data = new Product
            {
                PName = product.PName,
                PImage = product.PImage.FileName

            };

            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (Directory.Exists(imagesFolder)) {

                Directory.CreateDirectory(imagesFolder);
            }

            var imagsFile = Path.Combine(imagesFolder, product.PImage.FileName);
            using (var Stream = new FileStream(imagesFolder, FileMode.Create)) {

                product.PImage.CopyToAsync(Stream);

            }

            _db.Products.Add(data);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putProduct([FromForm] postProducts product, int id)
        {
            var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            var imagsFile = Path.Combine(imagesFolder, product.PImage.FileName);
            using (var Stream = new FileStream(imagsFile, FileMode.Create))
            {
                await product.PImage.CopyToAsync(Stream);
            }

            var p = _db.Products.FirstOrDefault(p => p.PId == id);
            if (p == null)
            {
                return NotFound();
            }

            p.PName = product.PName;
            p.PImage = product.PImage.FileName;

            _db.Products.Update(p);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}

