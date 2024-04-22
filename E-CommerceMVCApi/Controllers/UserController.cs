using E_CommerceMVCApi.Models;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {            
          if (ModelState.IsValid)
            {
                userService.AddUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        
    }
}
