using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Mời nhập tài khoảng:))")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu:))")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}