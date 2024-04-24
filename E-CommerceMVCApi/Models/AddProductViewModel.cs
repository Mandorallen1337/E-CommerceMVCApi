using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVCApi.Models
{
    public class AddProductViewModel
    {
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public double Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
