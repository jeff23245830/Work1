using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service.Interfaces
{
    public interface IVideoService
    {
        Task<VideoPlayViewModel> GetVideoList();
        Task UpdateVideoIntro(VideoPlayViewModel model);
        Task AddVideo(VideoPlayViewModel model);
        Task<VideoPlayViewModel> GetIdtoVIdeo(Guid Id);
    }
}
