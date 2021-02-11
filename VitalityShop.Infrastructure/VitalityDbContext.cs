using System;
using System.Collections.Generic;
using System.Text;
using VitalityShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace VitalityShop.Infrastructure
{
    public class VitalityDbContext : DbContext
    {
        public VitalityDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Zip> ZipCodes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Constraints(modelBuilder);
        }

        private void Constraints(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Zip>().HasIndex(e => e.ZipCode).IsUnique();
            modelbuilder.Entity<Zip>().HasIndex(e => e.CityName).IsUnique();
        }
    }
}
