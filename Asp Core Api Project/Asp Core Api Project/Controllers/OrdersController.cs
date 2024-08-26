//using Asp_Core_Api_Project.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Asp_Core_Api_Project.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersController : ControllerBase
//    {

//        private readonly MyDbContext _db;

//        public OrdersController(MyDbContext db)
//        {

//            _db = db;

//        }


//        [HttpGet]
        
//        public IActionResult getAllOrders() {

//            var AllOrders = _db.Orders.ToList();
//            return Ok(AllOrders);
//        }



//        [HttpGet("{id}")]
//        public IActionResult GetORderById(int id)
//        {

//            if (id == 0)
//            {

//                return NotFound();
//            }

//            var GetOrdersByID = _db.Orders.Find(id);

//            return Ok(GetOrdersByID);
//        }


//        [HttpDelete("{id}")]
//        public IActionResult deleteOrder(int id)
//        {

//            if (id < 1)
//            {

//                return NoContent();
//            }

//            var deleteOrderById = _db.Orders.Find(id);

//            _db.Orders.Remove(deleteOrderById);
//            _db.SaveChanges();
//            return Ok();


//        }

//    }
//}
