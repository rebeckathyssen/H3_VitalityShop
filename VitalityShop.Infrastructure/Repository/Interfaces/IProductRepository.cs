using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VitalityShop.Domain.Models;

namespace VitalityShop.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task <IEnumerable<Product>> GetAllProducts();

        Task<Product> GetProduct(int id);

        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);
    }
}
