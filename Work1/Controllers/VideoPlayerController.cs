using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Service.Interfaces;

namespace Work1.Controllers
{
    public class VideoPlayerController : Controller
    {
        private readonly IVideoService _VideoService;

        public VideoPlayerController(IVideoService videoService)
        {
            _VideoService = videoService;
        }




        public async Task<IActionResult> IndexAsync()
        {
            //取得影片列表
            var viewModel = await _VideoService.GetVideoList();

            return View(viewModel);
             
        }



        public IActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PlayVIdeoAsync(Guid Id)
        {

            var viewModel = await _VideoService.GetIdtoVIdeo(Id); 

            return View(viewModel);
        }

    }
}



