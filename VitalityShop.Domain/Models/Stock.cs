using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Stock // Which stock? Fjernlager?
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductQuantity { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
