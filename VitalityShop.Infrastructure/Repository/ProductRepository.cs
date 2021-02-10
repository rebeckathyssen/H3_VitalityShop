using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalityShop.Domain.Models;
using VitalityShop.Infrastructure.Repository.Interfaces;

namespace VitalityShop.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly VitalityDbContext dbContext;

        // Constructor
        public ProductRepository(VitalityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Method for returning all products
        public virtual async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await dbContext.Products.Include(x => x.Stock).ToListAsync();
            return products;
        }

        // Method for returning 1 product based on id
        public virtual async Task<Product> GetProduct(int id)
        {
            //var product = dbContext.Products.FindAsync(id);
            //var product = dbContext.Products.Include(x => x.Stock);
            var product = await dbContext.Products.Include(x => x.Stock).FirstOrDefaultAsync(x => x.ProductId == id);
            return product;
            
        }

        // Method for creating product
        public virtual async Task<Product> CreateProduct(Product product)
        {
            await dbContext.AddAsync(product);
            dbContext.SaveChanges();
            return product;
        }

        // Method for editing/updating product
        public virtual async Task<Product> UpdateProduct (Product product)
        {
            var entity = dbContext.Products.Attach(product);
            dbContext.Update(product);
            entity.State = EntityState.Modified;
            dbContext.SaveChanges();
            return product;
        }

        // Method for deleing product
        public virtual async Task<bool> DeleteProduct(int id)
        {
            var entity = await GetProduct(id);
            
            if (entity == null) return false;

            var entityState = dbContext.Attach(entity);
            entityState.State = EntityState.Deleted;

            dbContext.Remove(entity);

            dbContext.SaveChanges();

            return true;
        }
    }
}
