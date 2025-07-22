using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VideoPlayViewModel
    {
        public string? VideoUrl;/// Images/Product/1.jpg 前後不加/

        public Guid Id;

        public string Name;

        public string introduce;

        public List<Video> VideoList { get; set; } = new List<Video>();
    } 
}
