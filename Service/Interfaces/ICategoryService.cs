using Repository.Data;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
         
        Task AddCategory(CategoryViewModel model);

        Task EditCategory(CategoryViewModel model);



        Task<CategoryViewModel> GetCategoryById(Guid Id);


        Task DeletById(Guid Id);

        Task<CategoryViewModel> GetPagedCategoriesAsync(int pageNumber, int pageSize);
    }
}
