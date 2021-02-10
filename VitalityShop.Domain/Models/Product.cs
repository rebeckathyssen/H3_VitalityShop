using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; } // the price for the product right now
        public string ImgSrc { get; set; }
        // FK for ProductCategory
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        // FK  for Stock
        public int StockId { get; set; }
        public Stock Stock { get; set; } // A specific product can only be in one warehouse

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
