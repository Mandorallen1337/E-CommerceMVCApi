using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVCApi.Models
{
    public class AddOrderViewModel
    {
        public int OrderId { get; set; }
        
        public double TotalPrice { get; set; }
    }
}
