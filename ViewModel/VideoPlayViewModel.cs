using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class VideoPlayViewModel
    {
        [DisplayName("影片檔案")]
        public string? VideoUrl { get; set; }/// Images/Product/1.jpg 前後不加/

        public Guid Id { get; set; }

        [DisplayName("影片名稱")]
        public string Name{ get; set; }
        [DisplayName("介紹")]
        public string introduce{ get; set; }

        public List<Video> VideoList { get; set; } = new List<Video>();
    } 
}
