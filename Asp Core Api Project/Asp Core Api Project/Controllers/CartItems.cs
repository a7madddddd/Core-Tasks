using Asp_Core_Api_Project.DTOs;
using Asp_Core_Api_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Asp_Core_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItems : ControllerBase
    {

        private readonly MyDbContext _db;

        public CartItems(MyDbContext db)
        {

            _db = db;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _db.CartItems.Include(c => c.PIdNavigation).Select(
                x => new
                {
                    PId = x.PId,
                    CartItemId = x.CartItemId,
                    CartId = x.CartId,
                    Quantity = x.Quantity,
                    PDTO = new productDTO
                    {
                        PId = x.PId,
                        PName = x.PIdNavigation.PName,
                        PDes = x.PIdNavigation.PDes,
                        PPric = x.PIdNavigation.PPric,
                        PImage = x.PIdNavigation.PImage
                    }
                }
            ).ToList();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddItems([FromBody] AddItemsRequestDTO APDTO)
        {
            var data = new CartItem
            {
                CartItemId = APDTO.CartItemId,
                CartId = APDTO.CartId,
                Quantity = APDTO.Quantity,
                PId = APDTO.PId,

            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }
        [HttpPut("{id}")]
        public IActionResult PutCategory([FromBody] EditCartItemRequest EditRequist, int id)
        {
            
            var EditCartItem = _db.CartItems.FirstOrDefault(c => c.CartItemId == id);
               EditCartItem.Quantity = EditRequist.Quantity;

            _db.CartItems.Update(EditCartItem);
            _db.SaveChanges();

            return Ok();
        }


        [HttpDelete("Api/{id}")]
        public IActionResult DeleteCartItem(int id)
        {
            var deleteCartItem = _db.CartItems.FirstOrDefault(c => c.CartItemId == id);

            if (deleteCartItem == null)
            {
                return NotFound(); // Return 404 if item not found
            }

            _db.Remove(deleteCartItem);
            _db.SaveChanges();

            return NoContent(); // Return 204 No Content on successful deletion
        }


    }
}
