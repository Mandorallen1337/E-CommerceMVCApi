using E_CommerceMVCApi.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVCApi.Models
{
    public class AddOrderViewModel
    {
        public int OrderId { get; set; }
        
        public double TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public User User { get; set; }
    }
}
