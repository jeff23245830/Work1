using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("電子信箱")]
        [Required]
        public string Email { get; set; }
        [DisplayName("使用者名稱")]
        [Required]
        public string Name { get; set; }
        [DisplayName("密碼")]
        [Required]
        public string Password { get; set; }
        [DisplayName("確認密碼")]
        [Required]
        public string ConfirmPassword { get; set; } 
    }
}
