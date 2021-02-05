using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class OrderProducts // aka orderlines
    {
        public int OrderProductsId { get; set; }
        public decimal Price { get; set; } // Price here because we need to know what the customer paid the minute they bought the product - it could change later
        public int Amount { get; set; }
        // Foreign key for order
        public int OrderId { get; set; }
        public Order Order { get; set; }
        // Foreign key for product
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
