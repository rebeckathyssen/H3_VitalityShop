using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace VitalityShop.Infrastructure
{
    public class VitalityDbContext : DbContext
    {
        public VitalityDbContext(DbContextOptions options) : base(options) {

            /*using (var context = new VitalityDbContext(options))
            {
                // As we've turned off the normal identifier creation of zipcodes, we want to create our own:
                var odensev = new Zip() { ZipCode = 5200, CityName = "Odense V" };
                context.ZipCodes.Add(odensev);

                var odensem = new Zip() { ZipCode = 5230, CityName = "Odense M" };
                context.ZipCodes.Add(odensem);

                var odenses = new Zip() { ZipCode = 5260, CityName = "Odense S" };
                context.ZipCodes.Add(odenses);

                var odensec = new Zip() { ZipCode = 5000, CityName = "Odense C" };
                context.ZipCodes.Add(odensec);

                var odensen = new Zip() { ZipCode = 5270, CityName = "Odense N" };
                context.ZipCodes.Add(odensen);

                context.SaveChanges();
            }*/
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Zip> ZipCodes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
