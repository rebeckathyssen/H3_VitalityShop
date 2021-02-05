using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly VitalityDbContext dbContext;

        public ProductRepository(VitalityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Method for returning all products
        public IEnumerable<Product> GetAllProducts()
        {
            var products = dbContext.Products.ToList();
            return products;
        }

        // Method for returning 1 product based on id
        public Product GetProduct(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            return product;
        }

        // Method for creating product
        public Product CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        // Method for editing/updating product
        public Product UpdateProduct (Product product)
        {
            var entity = dbContext.Products.Attach(product);
        }

        // Method for deleing product
        public bool DeleteProduct(int id)
        {

        }
    }
}
