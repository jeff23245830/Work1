using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        // --- Create ---
        public async Task AddAsync(Product category)
        {
            await _context.Products.AddAsync(category);
        }

        // --- Read ---
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products
                             .Include(p => p.Category) // 確保載入類別
                             .FirstOrDefaultAsync(p => p.Id == id);
        }


        // --- Update ---
        public void Update(Product category)
        {
            _context.Products.Update(category); // Entity Framework 會追蹤變更，State 會設置為 Modified
            // 或者：
            // _context.Entry(category).State = EntityState.Modified;
        }

        // --- Delete ---
        public void Delete(Product category)
        {
            _context.Products.Remove(category);
        }

        // --- Save Changes ---
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithCategoriesAsync()
        {
            return await _context.Products
                             .Include(p => p.Category) // **核心：載入 Category 導覽屬性**
                             .ToListAsync();
        }
    }
}
