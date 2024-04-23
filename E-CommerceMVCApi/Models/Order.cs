using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceMVCApi.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
                
        [Required]
        public double TotalPrice { get; set; }
        

        public List<Product> ProductList { get; set; }

        public Order(int orderId, double totalPrice)
        {
            OrderId = orderId;        
            TotalPrice = totalPrice;            
        }

        public Order()
        {
        }
    }
}
