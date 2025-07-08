using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class ProductService : IProductService
    {
        


        private readonly IProductRepository _IProductRepository;
        private readonly ICategoryRepository _ICategoryRepository;
        public ProductService(IProductRepository IProductRepository, ICategoryRepository iCategoryRepository)
        {
            _IProductRepository = IProductRepository;
            _ICategoryRepository = iCategoryRepository;
        }

        public async Task<ProductViewModel> GetProductById(Guid Id)
        {
            var CC = await _IProductRepository.GetByIdAsync(Id);
            var RR = new ProductViewModel
            {
                Id = CC.Id,
                Name = CC.Name,
                CategoryId = CC.Category.Id,
                CategoryName = CC.Category.Name,
                Weight = CC.Weight,
                Size = CC.Size,
                Price = CC.Price,
                ImageUrl = CC.ImageUrl,                
            };
            return RR;
        }

        public async Task<ProductViewModel> GetPagedProductssAsync(int pageNumber, int pageSize)
        {
            // 第一步：從 Repository 獲取所有類別數據。 D
            var allCategories = await _IProductRepository.GetAllProductsWithCategoriesAsync();

            // 第二步：計算總項目數。 
            int totalItems = allCategories.Count();

            // 第三步：在記憶體中進行分頁。
            // Skip() 和 Take() 也都是 System.Linq.Enumerable 提供的擴展方法，它們同樣在記憶體中操作。 
            var PorductPerPage = allCategories
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList(); // 轉換為 List 以便傳遞給 ViewModel

            // 第四步：計算總頁數
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);


            // 第五步：創建並填充 ViewModel
            var viewModel = new ProductViewModel
            {
                ProductList = PorductPerPage,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return viewModel;
        }

        public async Task AddProduct(ProductViewModel model)
        {

            var NewModel = new Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CategoryId = model.CategoryId,
                Weight = model.Weight,
                Size = model.Size,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                IsAlready = true 
            };

            _IProductRepository.AddAsync(NewModel);
            await _IProductRepository.SaveChangesAsync();
             
        }

        public Task<ProductViewModel> UpdataProduct(ProductViewModel model)
        {
            throw new NotImplementedException();
        }

         
    }
}
