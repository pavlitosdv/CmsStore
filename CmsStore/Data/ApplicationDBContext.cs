using CmsStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsStore.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Fruits" , Slug = "fruit"});
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Clothes", Slug ="clothes" });

            //seed categories
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Apples", Slug = "Apples", Description = "Fruit product", Price = 3, Image = "apples.jpg", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Bananas", Slug = "Bananas", Description = "Fruit product", Price = 2, Image = "bananas.jpg", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "grapes", Slug = "grapes", Description = "Fruit product", Price = 1, Image = "grapes.jpg", CategoryId = 1 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "black shirt", Slug = "black-shirt", Description = "shirt", Price = 35, Image = "black shirt.jpg", CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "blue shirt", Slug = "blue-shirt", Description = "blue color", Price = 38, Image = "blue shirt.jpg", CategoryId = 2 });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "pink shirt", Slug = "pink-shirt", Description = "pink product", Price = 55, Image = "pink shirt.jpg", CategoryId = 2 });


        }
    }
}
