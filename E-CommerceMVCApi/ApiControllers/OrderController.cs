using E_CommerceMVCApi.Models.Entities;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVCApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            return Ok(orderService.GetAllOrders());
        }

        [HttpPost("AddOrder")]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                orderService.AddOrder(order);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                orderService.UpdateOrder(order);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteOrder")]
        public IActionResult DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
            return Ok();
        }
    }
}
