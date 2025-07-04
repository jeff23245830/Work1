using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryEditViewModel
    {

        [DisplayName("類別名稱")]
        public string Name { get; set; }
        [DisplayName("類別排序")]
        public string OrderBy { get; set; }

    }
}
