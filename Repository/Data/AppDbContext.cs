using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "第1個類別", OrderBy = 1 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000002"), Name = "第2個類別", OrderBy = 2 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000003"), Name = "第3個類別", OrderBy = 3 },    
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000004"), Name = "第4個類別", OrderBy = 4 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000005"), Name = "第5個類別", OrderBy = 5 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000006"), Name = "第6個類別", OrderBy = 6 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000007"), Name = "第7個類別", OrderBy = 7 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000008"), Name = "第8個類別", OrderBy = 8 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000009"), Name = "第9個類別", OrderBy = 9 },
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000010"), Name = "第10個類別", OrderBy = 10 }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Account = "admin@admin.com",
                    Name = "Admin",
                    Password = "1224",
                    Email = "admin@admin.com",
                    CreatedTime = DateTime.Now,
                    RoleId = new Guid("00000000-0000-0000-0000-000000000001"), 
                }
               );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"), 
                    Name = "好喝的水",
                    CategoryId = new Guid("00000000-0000-0000-0000-000000000001"),
                    Price = 100,
                    Size = "大",
                    Weight = 20,
                    ImageUrl ="\\images\\1.jpg",
                    CreateTime = DateTime.Now,
                    IsAlready = true
                }
               );


            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"), 
                    Name = "Admin",
                    Level = 1
                },
                new Role
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000002"),
                    Name = "Manager",
                    Level = 2
                },
                new Role
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000003"),
                    Name = "User",
                    Level = 3
                }
               );

        }          
    }
}
