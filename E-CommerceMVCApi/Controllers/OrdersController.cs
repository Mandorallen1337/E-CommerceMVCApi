using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models;
using E_CommerceMVCApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVCApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DatabaseContext dbContext;

        public OrdersController(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Orders");
            
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var order = await dbContext.Orders.ToListAsync();

            return View(order);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order viewModel)
        {
            var order = await dbContext.Orders.FindAsync(viewModel.OrderId);

            if(order is not null)
            {
                order.TotalPrice = viewModel.TotalPrice;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Orders");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await dbContext.Orders.FindAsync(id);

            if(order is not null)
            {
                dbContext.Orders.Remove(order);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Orders");
        }
    }
}
