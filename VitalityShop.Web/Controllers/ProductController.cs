using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitalityShop.Domain.Models;
using VitalityShop.Application.Interfaces;

namespace VitalityShop.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // Endpoint to get all products
        // We want to use IActionResult over ActionResult because we can make our own responses with the interface itself, like the
            // custommade "Ok" below - whereas ActionResult only has a few different responses to pick from
        [HttpGet]
        public virtual async Task<IActionResult> GetAllProducts()
        {
            var res = await productService.GetAllProducts();
            return res != null ? (IActionResult)Ok(res) : BadRequest();
        }

        // Endpoint to get 1 product based on id
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                return Ok(await productService.GetProduct(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        // Endpoint to create a new product
        [HttpPost]
        public virtual async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                return Ok(await productService.CreateProduct(product));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        // Endpoint to update product
        [HttpPut]
        public virtual async Task<IActionResult> Put(Product product)
        {
            try
            {
                return Ok(await productService.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        // Endpoint to delete product
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(await productService.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}
