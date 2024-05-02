
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
            if(IsEmailExist(user.Email))
            {
                throw new ValidationException("Email already exist");
            }
            else
            {
                user.Password = HashPassword(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
            }
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

        public bool UserLogin(string email, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true; 
                //return user;
            }
            else
            {
                return false;
                //return null; 
            }
        }


        public bool IsEmailExist(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }
    }
}
