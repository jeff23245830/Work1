using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using ViewModel;

namespace Work1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController (ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet("Index")]
        public async Task<IActionResult> IndexAsync(int pageNumber = 1, int pageSize = 5)
        {

            var viewModel = await _categoryService.GetPagedCategoriesAsync(pageNumber, pageSize);
            return View(viewModel);
        }

        [HttpPost("Index")]
        public async Task<IActionResult> IndexAsync()
        { 
            return View();
        }

        [HttpGet("Edit")]
        public async Task<IActionResult> Edit(CategoryViewModel model)
        {
            if (model.Id != Guid.Empty)
            {
                var viewModel = await _categoryService.GetCategoryById(model.Id);
                return View(viewModel);
            }
             
            return View();
        }

        [HttpPost("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CategoryViewModel model)
        {  
            if(model.Id != Guid.Empty)
            {

                await _categoryService.EditCategory(model);

                TempData["success"] = "類別更新成功";

                return RedirectToAction(nameof(Index));
            }
            await _categoryService.AddCategory(model);

            TempData["success"] = "類別新增成功";

            return RedirectToAction(nameof(Index));

        }

    }
}
