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
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Video entity)
        {
            await _context.Videos.AddAsync(entity);
        }

        public void Delete(Video entity)
        {
             _context.Videos.Remove(entity);
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video?> GetByIdAsync(Guid id)
        {
            return await _context.Videos
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Video entity)
        {
            _context.Videos.Update(entity);
        }
    }
}
