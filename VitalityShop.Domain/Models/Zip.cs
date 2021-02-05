using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VitalityShop.Domain.Models
{
    public class Zip
    {
        public int ZipId { get; set; }
        public int ZipCode { get; set; }
        public string CityName { get; set; }

        // So we can look up which users live in which cities
        public ICollection<User> Users { get; set; }
    }
}
