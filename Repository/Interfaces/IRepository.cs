using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        // 讀取操作
        Task<IEnumerable<TEntity>> GetAllAsync(); 
        Task<TEntity?> GetByIdAsync(TId id);// 假設所有實體都有 Guid ID 讀一個

        // 寫入操作
        Task AddAsync(TEntity entity);
        void Update(TEntity entity); // Update 通常不需要 async，因為通常是追蹤現有實體
        void Delete(TEntity entity);

        // 儲存變更 (DbContext 通常在 Repository 或 UnitOfWork 層儲存)
        Task<int> SaveChangesAsync();
    }
}
