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


        [HttpGet]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {

            var viewModel = await _categoryService.GetPagedCategoriesAsync(pageNumber, pageSize);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        { 
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var viewModel = await _categoryService.GetCategoryById(Id);
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(CategoryViewModel model)
        {
            try
            {
                if (model.Id != Guid.Empty && model.Name != null)
                {
                    await _categoryService.EditCategory(model);
                    TempData["success"] = "類別更新成功";
                    return RedirectToAction("Index");
                }
                if (model.Name != null && model.OrderBy != null)
                {
                    await _categoryService.AddCategory(model);
                    TempData["success"] = "類別新增成功";
                    return RedirectToAction("Index");
                }
                TempData["error"] = "類別新增失敗";
                return RedirectToAction("Index");
            }
            catch 
            {
                TempData["error"] = "類別新增失敗";
                return RedirectToAction("Index");
            }
             

        }


        #region API 

        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await _categoryService.DeletById(Id);
                return Json(new { success = true, message = "刪除成功" });
            }
            catch {

                return Json(new { success = false, message = "刪除失敗" });

            }


            
        }


        #endregion


    }
}
