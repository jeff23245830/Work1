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
        public async Task<ActionResult> Edit(ProductViewModel model ,IFormFile? file)
        {
            //上傳檔案_WebHostEnvironment時屬於意外 因為沒Services沒有IFormFile
            try
            {
                string wwwRootPath = _WebHostEnvironment.WebRootPath;

                // --- 核心邏輯：先判斷是新增還是修改 ---
                if (model.Id != Guid.Empty) // 判斷為「修改」操作
                {
                    // 在更新操作開始時，從資料庫獲取現有的圖片路徑，這比依賴前端傳入更可靠
                    string? oldImageUrlFromDb = null;
                    var existingProduct = await _ProductService.GetProductById(model.Id); // 假設有此服務方法
                    if (existingProduct != null)
                    {
                        oldImageUrlFromDb = existingProduct.ImageUrl;
                    }

                    if (file != null) // 有新圖片上傳
                    {
                        // --- 刪除舊圖片的邏輯 (僅在修改且有新圖時執行) ---
                        if (!string.IsNullOrEmpty(oldImageUrlFromDb)) // 使用從資料庫讀取到的舊路徑
                        {
                            // 獲取舊圖片的完整物理路徑，確保斜槓方向正確
                            string oldImagePath = Path.Combine(wwwRootPath, oldImageUrlFromDb.TrimStart('/').Replace("/", "\\"));
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // --- 保存新圖片的邏輯 ---
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, "Images\\Product"); // 使用反斜槓拼接物理路徑

                        // 確保目標資料夾存在
                        if (!Directory.Exists(productPath))
                        {
                            Directory.CreateDirectory(productPath);
                        }

                        string filePath = Path.Combine(productPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream); // 使用 CopyToAsync 更高效
                        }

                        // 更新模型中的圖片路徑 (相對路徑)，並統一為 Web 友好的正斜槓 `/` 格式
                        model.ImageUrl = Path.Combine("Images\\Product", fileName).Replace("\\", "/");
                    }
                    else // 沒有新檔案上傳 (修改操作，但沒有替換圖片)
                    {
                        // 將模型中的圖片路徑設定為從資料庫讀取到的舊圖片路徑，保留它
                        model.ImageUrl = oldImageUrlFromDb;
                    }
                     

                    await _ProductService.UpdateProduct(model);
                    TempData["success"] = "產品更新成功";
                    return RedirectToAction("ProductList");
                }
                else // 判斷為「新增」操作
                {
                    if (file != null) // 新增時有圖片上傳
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = Path.Combine(wwwRootPath, "Images\\Product"); // 使用反斜槓拼接物理路徑

                        // 確保目標資料夾存在
                        if (!Directory.Exists(productPath))
                        {
                            Directory.CreateDirectory(productPath);
                        }

                        string filePath = Path.Combine(productPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream); // 使用 CopyToAsync 更高效
                        }
                        // 更新模型中的圖片路徑 (相對路徑)，並統一為 Web 友好的正斜槓 `/` 格式
                        model.ImageUrl = Path.Combine("Images\\Product", fileName).Replace("\\", "/");
                    }
                    else
                    {
                        // 新增產品但沒有上傳圖片時，ImageUrl 應該保持為 null 或空字符串
                        model.ImageUrl = null;
                    }
                     
                    await _ProductService.AddProduct(model);
                    TempData["success"] = "產品新增成功";
                    return RedirectToAction("ProductList");
                }
            }
            catch (Exception ex) // 建議捕獲具體異常並記錄
            {

                string errorMessage = "操作失敗：";

                // 建議使用 ILogger 記錄完整例外細節，以便未來排查
                // _logger.LogError(ex, "資料保存失敗。");

                if (ex.InnerException != null)
                {
                    errorMessage += ex.InnerException.Message;
                    // 如果需要更詳細的堆棧追蹤，可以加上 ex.InnerException.StackTrace
                    // 甚至可以嘗試序列化 ex.InnerException 並顯示
                }
                else
                {
                    errorMessage += ex.Message;
                }

                TempData["error"] = errorMessage; // 顯示更詳細的錯誤訊息
                return RedirectToAction("ProductList"); // 或返回到表單讓用戶重新提交
            }

        }

        #region API 

        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await _ProductService.DeletProductById(Id);
                return Json(new { success = true, message = "刪除成功" });
            }
            catch
            {
                return Json(new { success = false, message = "刪除失敗" });

            }



        }


        #endregion
        
    } 
}
