using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceMVCApi.Models.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public double TotalPrice { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public User User { get; set; }


        public List<Product> ProductList { get; set; }

        public Order(int orderId, double totalPrice, DateTime orderDate, User user)
        {
            OrderId = orderId;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            User = user;
        }

        public Order()
        {
        }
    }
}
