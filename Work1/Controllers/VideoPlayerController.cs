using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using ViewModel;

namespace Work1.Controllers
{
    public class VideoPlayerController : Controller
    {
        private readonly IVideoService _VideoService;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public VideoPlayerController(IVideoService videoService , IWebHostEnvironment WebHostEnvironment)
        {
            _VideoService = videoService;
            _WebHostEnvironment = WebHostEnvironment;
        }




        public async Task<IActionResult> Index()
        {
            //取得影片列表
            var viewModel = await _VideoService.GetVideoList();

            return View(viewModel);
             
        }


        [HttpGet]
        public async Task<IActionResult> Upload(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var viewModel = await _VideoService.GetIdtoVIdeo(Id);
                return View(viewModel);
            }
            return View();
             
        }

        /// <summary>
        /// 上傳或編輯
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAsync(VideoPlayViewModel model, IFormFile? file)
        {
            //上傳檔案_WebHostEnvironment時屬於意外 因為沒Services沒有IFormFile
            try
            {
                string wwwRootPath = _WebHostEnvironment.WebRootPath;
                 
                if (model.Id != Guid.Empty) // 判斷為「修改」操作
                {
                    //修改標題
                    await _VideoService.UpdateVideoIntro(model);
                    TempData["success"] = "產品更新成功";
                    return RedirectToAction("Index");
                }
                else 
                {
                    //新增影片
                    if (file != null) // 上傳
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string videoDirectoryPath = Path.Combine(wwwRootPath, "Video", "Videos");

                        if (!Directory.Exists(videoDirectoryPath))
                        {
                            Directory.CreateDirectory(videoDirectoryPath);
                        }

                        string filePath = Path.Combine(videoDirectoryPath, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream); 
                        }
                        model.VideoUrl = Path.Combine("Video", "Videos", fileName).Replace("\\", "/"); 
                        await _VideoService.AddVideo(model);
                        TempData["success"] = "產品新增成功";
                        return RedirectToAction("Index");
                    }
                    else
                    {                                            
                        model.VideoUrl = null; 
                        TempData["error"] = "新增影片時，請務必選擇一個影片檔案上傳。"; // 顯示更詳細的錯誤訊息
                        return RedirectToAction("Index");
                    }

                    
                }
            }
            catch (Exception ex) // 建議捕獲具體異常並記錄
            {

                string errorMessage = "操作失敗：";


                if (ex.InnerException != null)
                {
                    errorMessage += ex.InnerException.Message;
                }
                else
                {
                    errorMessage += ex.Message;
                }

                TempData["error"] = errorMessage; 
                return RedirectToAction("Index"); 
            }
        }





        [HttpGet]
        public async Task<IActionResult> PlayVIdeoAsync(Guid Id)
        {

            var viewModel = await _VideoService.GetIdtoVIdeo(Id); 

            return View(viewModel);
        }

    }
}



