using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
