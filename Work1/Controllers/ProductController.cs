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

        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }
        public ActionResult Index()
        {
            return View();
        }

         
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> ProductListAsync(int pageNumber = 1, int pageSize = 5)
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
        public ActionResult Edit(ProductViewModel model)
        {

            return View();
        }
        public ActionResult Remove()
        {
            return View();
        }
    } 
}
