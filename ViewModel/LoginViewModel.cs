using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("電子信箱")]
        [Required]
        public string Email { get; set; }

        [DisplayName("密碼")]
        [Required]
        public string Password { get; set; }
    }
}
