using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Street { get; set; }
        public int Housenumber { get; set; }
        //Foreign key for zip
        public int ZipId { get; set; }
        public Zip UserZip { get; set; }
        // Foreign key for role
        public int RoleId { get; set; }
        public Role UserRole { get; set; }

        public ICollection<Order> Orders { get; set; }  // ICollection over List<> because this supports the "Add"-operations
        public ICollection<UserDepartment> UserDepartments { get; set; }
       
        //[ForeignKey("Userrole")] is not needed here because EFC already knows what FK are which based on the naming above
        
    }
}
