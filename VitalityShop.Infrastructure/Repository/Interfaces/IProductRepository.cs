using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;

namespace VitalityShop.Infrastructure.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int id);

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product);

        bool DeleteProduct(int id);
    }
}
