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
        public IActionResult postProducts([FromForm] postProducts product)
        {
            // Ensure the folder path to save the images
            var imagesFolderProducts = Path.Combine(Directory.GetCurrentDirectory(), "ProductsImages");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(imagesFolderProducts))
            {
                Directory.CreateDirectory(imagesFolderProducts);
            }

            // Initialize image name variable
            string imageName = null;

            // Handle image file upload if it's not null
            if (product.PImage != null)
            {
                // Generate the full path for the image file
                var imageFilePath = Path.Combine(imagesFolderProducts, product.PImage.FileName);
                imageName = product.PImage.FileName;

                // Save the image file to the specified path
                using (var stream = new FileStream(imageFilePath, FileMode.Create))
                {
                    product.PImage.CopyTo(stream); // Synchronous file copy
                }
            }

            // Create a new Product instance with the uploaded image name
            var dataa = new Product
            {
                PName = product.PName,
                PDes = product.PDes,
                PPric = product.PPric,
                PImage = imageName, // Save the image name in the database
                CId = product.CId
            };

            // Add the product data to the database
            _db.Products.Add(dataa);
            _db.SaveChanges(); // Synchronous save changes operation

            return Ok();
        }
 
        //public IActionResult PostProduct([FromForm] postProducts product)
        //{
        //    // Ensure the folder path to save the images
        //    var imagesFolderproducts = Path.Combine(Directory.GetCurrentDirectory(), "productsImages");

        //    // Create the directory if it doesn't exist
        //    if (!Directory.Exists(imagesFolderproducts))
        //    {
        //        Directory.CreateDirectory(imagesFolderproducts);
        //    }

        //    // Handle image file upload if it's not null
        //    string imageName = null;
        //    if (product.PImage != null)
        //    {
        //        imageName = product.PImage.FileName; // Get the file name
        //        var imageFilePath = Path.Combine(imagesFolderproducts, imageName);

        //        // Save the image file to the specified path
        //        using (var stream = new FileStream(imageFilePath, FileMode.Create))
        //        {
        //            product.PImage.CopyTo(stream); // Save the file
        //        }
        //    }

        //    // Create a new Product instance with the uploaded image name
        //    var data = new Product
        //    {
        //        PName = product.PName,
        //        PImage = imageName, // Save the image name in the database
        //        PPric = product.PPric,
        //        PDes = product.PDes,
        //        CId = product.CId // Include the category ID if it's part of the model
        //    };

        //    // Add the product data to the database
        //    _db.Products.Add(data);
        //    _db.SaveChanges();

        //    return Ok();
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutProduct(int id, [FromForm] postProducts product)
        //{
        //    var existingProduct = _db.Products.FirstOrDefault(p => p.PId == id);

        //    if (existingProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    string imageName = existingProduct.PImage; // Keep existing image name if no new image is provided

        //    if (product.PImage != null)
        //    {
        //        var imagesFolderproducts = Path.Combine(Directory.GetCurrentDirectory(), "productsImages");
        //        if (!Directory.Exists(imagesFolderproducts))
        //        {
        //            Directory.CreateDirectory(imagesFolderproducts);
        //        }

        //        imageName = product.PImage.FileName; // Get the new image name
        //        var imageFilePath = Path.Combine(imagesFolderproducts, imageName);

        //        // Save the new image file
        //        using (var stream = new FileStream(imageFilePath, FileMode.Create))
        //        {
        //            product.PImage.CopyTo(stream);
        //        }
        //    }

        //    // Update the product details
        //    existingProduct.PName = product.PName;
        //    existingProduct.PImage = imageName; // Update image name
        //    existingProduct.PPric = product.PPric;
        //    existingProduct.PDes = product.PDes;
        //    existingProduct.CId = product.CId;

        //    _db.Products.Update(existingProduct);
        //    _db.SaveChanges();

        //    return Ok();
        //}



    }
}

