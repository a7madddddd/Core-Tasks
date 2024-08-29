namespace Asp_Core_Api_Project.DTOs
{
    public class AddItemsRequestDTO
    {
        public int PId { get; set; }
        public int? CartId { get; set; }
        public int Quantity { get; set; }
    }
}
