using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace Work1.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Edit")]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost("Edit")]
        public IActionResult Edit(CategoryEditViewModel model)
        {
            return View(model);
        }

    }
}
