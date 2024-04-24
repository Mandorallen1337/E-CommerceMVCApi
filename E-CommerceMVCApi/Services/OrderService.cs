
using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models.Entities;

namespace E_CommerceMVCApi.Services
{
    public class OrderService
    {
        DatabaseContext db;
        public OrderService(DatabaseContext databaseContext)
        {
            db = databaseContext;            
        }
        public void AddOrder(Order order)
        {
           db.Orders.Add(order);
            db.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            if (id != 0)
            {
                Order order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
            }   
        }

        public List<Order> GetAllOrders()
        {
            return new List<Order>();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
            // Tror inte denna funktion behövs då man får skapa en ny order om man vill ha något annat;
        }
    }
}
