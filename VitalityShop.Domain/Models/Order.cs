using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.Date;
        public DateTime Updated { get; set; }
        // Foreign key for user
        public int UserId { get; set; }
        public User User { get; set; }
        // Foreign key for status
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
