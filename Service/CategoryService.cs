using Repository;
using Repository.Data;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        public CategoryService(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        public async Task AddCategory(CategoryViewModel model)
        {
            var NewModel =new Category{
                Id = Guid.NewGuid(),
                Name = model.Name,
                OrderBy = model.OrderBy
            };

            _CategoryRepository.AddAsync(NewModel);
            await _CategoryRepository.SaveChangesAsync();

        }

        public async Task EditCategory(CategoryViewModel model)
        {
            var OldModel = await _CategoryRepository.GetByIdAsync(model.Id);

            OldModel.Name = model.Name;
            OldModel.OrderBy = model.OrderBy;

            _CategoryRepository.Update(OldModel);
            await _CategoryRepository.SaveChangesAsync();
            
        }

        public async Task<CategoryViewModel> GetCategoryById(Guid Id)
        {
            var CC = await _CategoryRepository.GetByIdAsync(Id);
            var RR = new CategoryViewModel
            {
                Id = CC.Id,
                Name = CC.Name,
                OrderBy = CC.OrderBy
            };
            return RR;
        }

        public async Task<CategoryViewModel> GetPagedCategoriesAsync(int pageNumber, int pageSize)
        {
            // 第一步：從 Repository 獲取所有類別數據。 D
            var allCategories = await _CategoryRepository.GetAllAsync();

            // 第二步：計算總項目數。 
            int totalItems = allCategories.Count();

            // 第三步：在記憶體中進行分頁。
            // Skip() 和 Take() 也都是 System.Linq.Enumerable 提供的擴展方法，它們同樣在記憶體中操作。 
            var categoriesPerPage = allCategories
                                    .Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList(); // 轉換為 List 以便傳遞給 ViewModel

            // 第四步：計算總頁數
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            
            // 第五步：創建並填充 ViewModel
            var viewModel = new CategoryViewModel
            {
                CategoryList = categoriesPerPage,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems
            };

            return viewModel;
        }
    }
}
