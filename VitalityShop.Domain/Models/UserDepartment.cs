using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class UserDepartment
    {
        public int UserDepartmentId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        // EFC requires navigation properties to be virtual so lazy loading and efficient change tracking is supported (in other words it works better with Linq)
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }
}
