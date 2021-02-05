using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;

namespace VitalityShop.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProduct(int id);
    }
}
