
using E_CommerceMVCApi.Models;

namespace E_CommerceMVCApi.Services
{
    public class ProductService
    {
        DatabaseContext db;
        public ProductService(DatabaseContext databaseContext)
        {
            db = databaseContext;            
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges(); 
        }

        public void DeleteProduct(int id)
        {
            if (id != 0)
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>();
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges(); 
        }
    }
}
