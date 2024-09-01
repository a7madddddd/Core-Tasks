using Asp_Core_Api_Project.Models;

namespace Asp_Core_Api_Project.DTOs
{
    public class CartItemRsposnceDTO
    {
        public int CartItemId { get; set; }

        public int? CartId { get; set; }

        public int Quantity { get; set; }

        public productDTO PDTO { get; set; }
        
    }

    public class productDTO {
    
        public int ?PId { get; set; }

        public string PName { get; set; }

        public string? PDes { get; set; }

        public string? PPric { get; set; }
        public string? PImage { get; set; }



    }
}
