using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("產品名稱")]
        public string Name { get; set; }
        [DisplayName("產品價格")]
        public int Price { get; set; }
        [DisplayName("產品大小")]
        public string Size { get; set; }
        [DisplayName("產品重量(KG)")]
        public int Weight { get; set; }

        [DisplayName("產品圖片")]
        public string? ImageUrl { get; set; }
        
        public Guid CategoryId { get; set; }
        [DisplayName("產品類別")]
        public string CategoryName { get; set; }
        public int PageNumber { get; set; } // 當前頁碼
        public int PageSize { get; set; }   // 每頁顯示的項目數
        public int TotalPages { get; set; } // 總頁數
        public int TotalItems { get; set; } // 總項目數

        public List<Product> ProductList { get; set; }
    }
}
