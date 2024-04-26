using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace E_CommerceMVCApi.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public List<Order> Orders { get; set; }


        public User(string username, string password, string email)
        {

            Username = username;
            Password = password;
            Email = email;
        }

        public User()
        {
        }
    }
}
