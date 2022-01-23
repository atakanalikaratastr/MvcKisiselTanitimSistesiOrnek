using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTier.WebUI.Controllers
{
    public class HomeController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDAL());
        // GET: Home
        public ActionResult Index(int? id)
        {
            
            User user = userManager.GetUserByUserId(userManager.GetUserList().FirstOrDefault().UserId);

            return View(user);
        }
    }
}