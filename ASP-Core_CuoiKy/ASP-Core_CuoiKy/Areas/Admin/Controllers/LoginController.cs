using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_CuoiKy.Areas.Admin.Models;
using ASP_Core_CuoiKy.DAO;
using ASP_Core_CuoiKy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ASP_Core_CuoiKy.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly OnlineShopContext db;
        public LoginController(OnlineShopContext context)
        {
            db = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User us = db.User.SingleOrDefault(p => p.UserName == loginModel.userName && p.Password == Encryptor.MD5Hash(loginModel.passWord));
                if(us == null)
                {
                    ModelState.AddModelError("loi", "Sai username hoặc password");
                }
               // HttpContext.Session.SetString("userName", us.UserName);
                HttpContext.Session.Set("userName", us);
                
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}