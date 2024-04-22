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
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }

        public enum Status { Pending, Delivered }

        public Order(int orderId, string username, int quantity, double totalPrice)
        {
            OrderId = orderId;            
            Username = username;
            Quantity = quantity;
            TotalPrice = totalPrice;            
        }

        public Order()
        {
        }
    }
}
