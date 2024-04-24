using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceMVCApi.Models.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public double Price { get; set; }
        [Required]
        [MaxLength(50)]
        public int Quantity { get; set; }


        public Product(int productId, string name, string description, double price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;

        }

        public Product()
        {
        }
    }
}
