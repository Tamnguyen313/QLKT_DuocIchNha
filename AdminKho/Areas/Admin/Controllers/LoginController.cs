using AdminKho.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminKho.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var ad = new UserAdmin();
                var result = ad.Login(model.UserName, model.Password);
                if (result == 1)
                {
                    var user = ad.getById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.id;
                    Session.Add(CommonConstants.USER_SESSION, userSession.UserName);
                    return RedirectToAction("Index", "Admin");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công!");
                }
            }
            return View(model);
        }
    }
}