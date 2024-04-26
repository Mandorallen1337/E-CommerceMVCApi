using E_CommerceMVCApi.Data;
using E_CommerceMVCApi.Models;
using E_CommerceMVCApi.Models.Entities;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceMVCApi.Controllers
{
    public class UsersController : Controller
    {
        private readonly DatabaseContext dbContext;
        UserService userService;

        public UsersController(DatabaseContext dbContext, UserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            userService.AddUser(user);           
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Users");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await dbContext.Users.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await dbContext.Users.FindAsync(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User viewModel)
        {
            var user = await dbContext.Users.FindAsync(viewModel.UserId);

            if(user is not null)
            {                
                user.Username = viewModel.Username;
                user.Password = viewModel.Password;
                user.Email = viewModel.Email;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Users");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(User viewModel)
        {
            var user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.UserId == viewModel.UserId);

            if(user is not null)
            {
                dbContext.Users.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Users");            
        }
            
        
    }
}
