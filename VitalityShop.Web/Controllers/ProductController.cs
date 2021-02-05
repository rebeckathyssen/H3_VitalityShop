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
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetAllProducts();
        }

        // Endpoint to get 1 product based on id
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return productService.GetProduct(id);
        }

        // Endpoint to create a new produkt
        [HttpPost]
        public Product CreateProduct(Product product)
        {
            return productService.CreateProduct(product);
        }

    }
}
