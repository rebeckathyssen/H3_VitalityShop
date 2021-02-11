using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VitalityShop.Domain.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
