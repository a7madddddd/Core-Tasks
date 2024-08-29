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

        public CartItems(MyDbContext db) {
        
            _db = db;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _db.CartItems.Select(
                x => new CartItemRsposnceDTO
                {
                    CartId = x.CartId,
                    Quantity = x.Quantity,
                    PDTO = new productDTO
                    {
                        PId = x.Product.PId,
                        PName = x.Product.PName,
                        PDes = x.Product.PDes,
                        PPric = x.Product.PPric,
                        PImage = x.Product.PImage
                    }
                }
            ).ToList();

            return Ok(data);
        }
        [HttpPost]
        public IActionResult AddItems([FromBody] AddItemsRequestDTO APDTO) {

            var data = new CartItem
            {
                CartId = APDTO.CartId,
                Quantity = APDTO.Quantity,
                PId = APDTO.PId,

            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }

    }
}
