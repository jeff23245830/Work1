using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Video
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string introduce { get; set; }


        [Required]
        [MaxLength(500)]
        public string? VideoUrl { get; set; }
    }
}
