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


        }          
    }
}
