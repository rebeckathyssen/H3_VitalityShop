using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VitalityShop.Application.Interfaces;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        // Constructor
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // Method for returning all products
        public virtual async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await productRepository.GetAllProducts();
        }

        // Method for returning 1 product
        public virtual async Task<Product> GetProduct(int id)
        {
            return await productRepository.GetProduct(id);
        }

        // Method for creating a new product
        public virtual async Task<Product> CreateProduct(Product product)
        {
            return await productRepository.CreateProduct(product);
        }

        // Method for updating
        public virtual async Task<Product> UpdateProduct(Product product)
        {
            return await productRepository.UpdateProduct(product);
        }

        // Method for deleting
        public virtual async Task<bool> DeleteProduct(int id)
        {
            return await productRepository.DeleteProduct(id);
        }
    }
}
