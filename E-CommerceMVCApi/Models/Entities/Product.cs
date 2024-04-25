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

        [MaxLength(50)]
        public string Size { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        


        public Product(int productId, string name, string size, string category, string description, double price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Size = size;
            Category = category;          

        }

        public Product()
        {
        }
    }
}
