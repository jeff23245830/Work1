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
        public DbSet<Video> Videos { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = new Guid("00000000-0000-0000-0000-000000000001"), Name = "預設類別", OrderBy = 1 }
           
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
                    ImageUrl ="Images/Product/1.jpg",
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

            modelBuilder.Entity<Video>().HasData(
                new Video
                {
                    Id = new Guid("00000000-0000-0000-0000-000000000001"),
                    Name = "測試影片1",
                    introduce = "介紹",
                    VideoUrl = "Video/Video/1.mp4"

                } 
               );

        }          
    }
}
