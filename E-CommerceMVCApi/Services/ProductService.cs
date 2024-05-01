
using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            return db.Products.ToList();
            
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return db.Products.FromSql($"SELECT * FROM Products WHERE Category = {category} LIMIT 6").ToList();
        }

        public void UpdateProduct(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges(); 
        }

        public object? GetProductById(int id)
        {
            return db.Products.Find(id);            
        }

        public object? GetImageById(int id)
        {
            
            return db.Images.Find(id);
        }

    }
}
