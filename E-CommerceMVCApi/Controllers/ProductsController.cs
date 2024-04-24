using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models;
using E_CommerceMVCApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVCApi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DatabaseContext dbContext;

        public ProductsController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            var product = new Product
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Quantity = viewModel.Quantity
            };
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await dbContext.Products.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await dbContext.Products.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            var product = await dbContext.Products.FindAsync(viewModel.ProductId);

            if(product is not null)
            {
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Description = viewModel.Description;
                product.Quantity = viewModel.Quantity;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product viewModel)
        {
            var product = await dbContext.Products.AsNoTracking().FirstOrDefaultAsync(u => u.ProductId == viewModel.ProductId);

            if (product is not null)
            {
                dbContext.Products.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Products");
        }


    }
}
