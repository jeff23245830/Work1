using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;
using ViewModel;

namespace Work1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _ProductService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductController(IProductService ProductService, IWebHostEnvironment WebHostEnvironment)
        {
            _ProductService = ProductService;
            _WebHostEnvironment = WebHostEnvironment;
        }
        public ActionResult Index()
        {
            return View();
        }

         
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> ProductList(int pageNumber = 1, int pageSize = 5)
        {
            var viewModel = await _ProductService.GetPagedProductssAsync(pageNumber, pageSize);
            return View(viewModel);
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Guid Id)
        {

            if (Id != Guid.Empty)
            {
                var viewModel = await _ProductService.GetProductById(Id);
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model ,IFormFile? file)
        {
            try
            {
                string wwwRootPath = _WebHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Product");
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    model.CategoryId = new Guid("00000000-0000-0000-0000-000000000001");
                    model.ImageUrl = @"\Images\Product\" + fileName;
                    _ProductService.AddProduct(model);
                    TempData["success"] = "產品新增成功";
                    return RedirectToAction("ProductList");
                }
                TempData["error"] = "產品新增失敗";
                return RedirectToAction("ProductList");
            } catch {
                TempData["error"] = "產品新增失敗";
                return RedirectToAction("ProductList");
            }
           
        }
        public ActionResult Remove()
        {
            return View();
        }
    } 
}
