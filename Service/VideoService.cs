using Repository;
using Repository.Entities;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _VideoRepository;
        public VideoService(IVideoRepository VideoRepository)
        {
            _VideoRepository = VideoRepository;
        }

        public async Task AddVideo(VideoPlayViewModel model)
        {

            var NewModel = new Video
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                introduce = model.introduce,
                VideoUrl = model.VideoUrl

            };

            await _VideoRepository.AddAsync(NewModel);
            await _VideoRepository.SaveChangesAsync();
        }

        public async Task<VideoPlayViewModel> GetIdtoVIdeo(Guid Id)
        {
            var onevideo = await _VideoRepository.GetByIdAsync(Id);

            var viewModel = new VideoPlayViewModel
            {
                Id = onevideo.Id,
                VideoUrl = onevideo.VideoUrl,
                Name = onevideo.Name,
                introduce = onevideo.introduce,
            };

            return viewModel;
        }

        public async Task<VideoPlayViewModel> GetVideoList()
        {
            var allVideos = await _VideoRepository.GetAllAsync();
            var viewModel = new VideoPlayViewModel
            {
                VideoList = allVideos.ToList()  
            }; 
            return viewModel; 
        }

        public async Task UpdateVideoIntro(VideoPlayViewModel model)
        {
            var onevideo = await _VideoRepository.GetByIdAsync(model.Id);
            onevideo.Name = model.Name;
            onevideo.introduce = model.introduce;

            _VideoRepository.Update(onevideo);
            await _VideoRepository.SaveChangesAsync();
             

        }
    }
}
