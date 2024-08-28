using Asp_Core_Api_Project.Models;

namespace Asp_Core_Api_Project.DTOs
{
    public class postProducts
    {
        public string? PName { get; set; }

        public string? PDes { get; set; }

        public string? PPric { get; set; }

        public IFormFile? PImage { get; set; }
        public int? CId { get; set; }

    }
}
