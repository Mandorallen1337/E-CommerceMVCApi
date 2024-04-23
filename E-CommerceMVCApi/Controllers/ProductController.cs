using E_CommerceMVCApi.Models;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceMVCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(productService.GetAllProducts());
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
          if (ModelState.IsValid)
            {
                productService.AddProduct(product);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.UpdateProduct(product);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return Ok();
        }
    }
}
