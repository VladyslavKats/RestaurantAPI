using Microsoft.EntityFrameworkCore;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DAL.EF
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userRole = new Role { Name = "customer" };
            var adminRole = new Role { Name = "admin" };
            modelBuilder.Entity<Role>().HasData(userRole, adminRole);
            modelBuilder.Entity<User>().HasData(new User { Login = "admin" , Password = "admin" , Role = adminRole }); ;
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
