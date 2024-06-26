﻿using E_CommerceMVCApi.Models.Entities;
using E_CommerceMVCApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace E_CommerceMVCApi.ApiControllers
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

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            return Ok(productService.GetProductById(id));
        }

        [HttpGet("GetProductsByCategory")]
        public IActionResult GetProductsByCategory(string category)
        {
            return Ok(productService.GetProductsByCategory(category));
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

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            productService.DeleteProduct(id);
            return Ok();
        }

        
    }
  }
