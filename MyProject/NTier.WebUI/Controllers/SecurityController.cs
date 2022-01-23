using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTier.WebUI.Controllers
{
    //[AllowAnonymous]
    public class SecurityController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDAL());
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var userIn = userManager.GetUserList().FirstOrDefault(x=>x.Mail == user.Mail && x.Password == user.Password);

            if (userIn != null)
            {
                FormsAuthentication.SetAuthCookie(user.Mail,false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.Mesaj = "Mail veya Şifre hatalı!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}