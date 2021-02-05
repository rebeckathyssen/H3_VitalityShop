using System;
using System.Collections.Generic;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
