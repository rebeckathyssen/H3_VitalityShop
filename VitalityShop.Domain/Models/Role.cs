using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace VitalityShop.Domain.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
