using Asp_Core_Api_Project.DTOs;
using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var a = _db.Categories.ToList();
            return Ok(a);
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
            var deleteCategory = _db.Categories.Include(x => x.Products).FirstOrDefault(c => c.CId == id);

            if (deleteCategory.Products.Any())
            {
                return BadRequest("gggg");
            }

            if (id < 1)
            {

                return NotFound();
            }

            _db.Remove(deleteCategory);
            _db.SaveChanges();

            return NoContent();

        }








        [HttpPost]
        public IActionResult CategoryReqestDots([FromForm] CategoryReqeust Categories)
        {
            // Create a new Category instance
            var data = new Category
            {
                CName = Categories.CName,
                CImage = Categories.CImage?.FileName // Handle potential null for CImage
            };

            // Set the folder path to save the images
            var imagesFolderCategory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            // Check if the path is a file
            if (Directory.Exists(imagesFolderCategory))
            {
                return StatusCode(500, "A file with the same name as the directory already exists.");
            }

            // Define the full path for the image file if CImage is not null
            if (Categories.CImage != null)
            {
                var imagsFile = Path.Combine(imagesFolderCategory, Categories.CImage.FileName);

                // Save the image file to the specified path
                using (var stream = new FileStream(imagsFile, FileMode.Create))
                {
                    Categories.CImage.CopyTo(stream);
                }
            }


            // Check if the directory does not exist and create it if necessary
            if (!Directory.Exists(imagesFolderCategory))
            {
                Directory.CreateDirectory(imagesFolderCategory);
            }

            

            // Add the category data to the database
            _db.Categories.Add(data);
            _db.SaveChanges();

            return Ok();
        }







        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct([FromForm] CategoryReqeust product, int id)
        //{
        //    var imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
        //    if (!Directory.Exists(imagesFolder))
        //    {
        //        Directory.CreateDirectory(imagesFolder);
        //    }

        //    var imageFile = Path.Combine(imagesFolder, Category.C.FileName);
        //    using (var stream = new FileStream(imageFile, FileMode.Create))
        //    {
        //        await Categories.CopyToAsync(stream);
        //    }

        //    var p = _db.Products.FirstOrDefault(p => p.PId == id);
        //    if (p == null)
        //    {
        //        return NotFound();
        //    }

        //    p.PName = product.PName;
        //    p.PImage = product.PImage.FileName;

        //    _db.Products.Update(p);
        //    await _db.SaveChangesAsync();
        //    return Ok();
        //}



    }
}
