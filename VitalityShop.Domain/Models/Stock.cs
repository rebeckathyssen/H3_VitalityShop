using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VitalityShop.Domain.Models
{
    public class Stock 
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public int ProductQuantity { get; set; }
        // JsonIgnore here to avoid Object Cycle-error
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
