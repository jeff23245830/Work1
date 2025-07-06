using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration; // 需要引用 Microsoft.Extensions.Configuration
using System.IO; // 需要引用 System.IO
 

namespace Repository.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. 建立一個 ConfigurationBuilder 來讀取 appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // 設定基礎路徑為應用程式執行目錄
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // 載入 appsettings.json
                .Build();

            // 2. 從 Configuration 中取得連接字串
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 如果連接字串為 null，拋出例外
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("DefaultConnection connection string not found in appsettings.json.");
            }

            // 3. 建立 DbContextOptionsBuilder 並配置資料庫提供者
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);

            // 4. 返回一個新的 AppDbContext 實例
            return new AppDbContext(builder.Options);
        }
    }
}
