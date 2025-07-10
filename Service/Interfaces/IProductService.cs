using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductViewModel model);
        Task DeletProductById(Guid id);
        Task UpdateProduct(ProductViewModel model);
        Task<ProductViewModel> GetProductById(Guid Id);

        Task<ProductViewModel> GetPagedProductssAsync(int pageNumber, int pageSize);
    }
}
