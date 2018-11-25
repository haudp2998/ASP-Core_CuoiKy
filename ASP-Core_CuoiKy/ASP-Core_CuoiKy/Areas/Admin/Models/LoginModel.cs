using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_CuoiKy.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập username")]
        public string userName { set; get; }
        [Required(ErrorMessage = "Vui lòng nhập password")]
        public string passWord { set; get; }
        public bool rememberMe { set; get; }
    }
}
