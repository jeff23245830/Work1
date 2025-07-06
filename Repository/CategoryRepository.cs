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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // --- Create ---
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        // --- Read ---
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }
         

        // --- Update ---
        public void Update(Category category)
        {
            _context.Categories.Update(category); // Entity Framework 會追蹤變更，State 會設置為 Modified
            // 或者：
            // _context.Entry(category).State = EntityState.Modified;
        }

        // --- Delete ---
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }

        // --- Save Changes ---
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        
    }
}
