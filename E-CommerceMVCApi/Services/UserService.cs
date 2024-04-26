
using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceMVCApi.Services
{
    public class UserService
    {
        DatabaseContext db;
        public UserService(DatabaseContext databaseContext)
        {
            db = databaseContext;            
        }
        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public void AddUser(User user)
        {
            user.Password = HashPassword(user.Password);
            db.Users.Add(user);
            db.SaveChanges();            
            
        }

        public void UpdateUser(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();            
        }

        public void DeleteUser(int id)
        {
            if (id != 0)
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }

        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public object? GetUserById(int id)
        {
            return db.Users.Find(id);
        }
    }
}
