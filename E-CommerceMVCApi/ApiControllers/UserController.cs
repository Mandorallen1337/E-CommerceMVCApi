using E_CommerceMVCApi.Models.Entities;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace E_CommerceMVCApi.ApiControllers
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

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.GetUserById(id));
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

        [HttpGet("UserLogin")]
        public IActionResult Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!userService.IsEmailExist(user.Email))
            {
                return BadRequest("Email doesn't exist.");
            }

            var result = userService.UserLogin(user.Email, user.Password);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Incorrect password.");
            }
        }





    }
}
