using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryViewModel
    {

        public Guid Id { get; set; } 
        [DisplayName("類別名稱")]
        public string Name { get; set; }
        [DisplayName("類別排序")]
        public int OrderBy { get; set; }

        public int PageNumber { get; set; } // 當前頁碼
        public int PageSize { get; set; }   // 每頁顯示的項目數
        public int TotalPages { get; set; } // 總頁數
        public int TotalItems { get; set; } // 總項目數

        public List<Category> CategoryList { get; set; } 
    } 
      

}
