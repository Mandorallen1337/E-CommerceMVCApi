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

        public UserController(UserService userService)
        {
            this.userService = userService;
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

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            userService.DeleteUser(id);
            return Ok();
        }


        
    }
}
