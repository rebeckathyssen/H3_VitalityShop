using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Application.Interfaces;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }
    }
}
