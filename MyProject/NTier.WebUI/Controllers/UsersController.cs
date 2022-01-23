using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;

namespace NTier.WebUI.Controllers
{
    public class UsersController : Controller
    {
        //private NTier_Context db = new NTier_Context();
        UserManager userManager = new UserManager(new EfUserDAL());

        // GET: Users
        public ActionResult Index()
        {

            //return View(db.Users.ToList());
            return View(userManager.GetUserList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = userManager.GetUserByUserId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "UserId,Name,SurName,Title,About,ImageURL,Mail,Password")] User user)
        {
            string ResimAdi;
            string adres;
            if (file != null)
            {
                ResimAdi = System.IO.Path.GetFileName(file.FileName);
                adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                user.ImageURL = ResimAdi;
            }
            if (ModelState.IsValid)
            {
                //db.Users.Add(user);
                //db.SaveChanges();
                userManager.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = userManager.GetUserByUserId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, [Bind(Include = "UserId,Name,SurName,Title,About,ImageURL,Mail,Password")] User user)
        {
            string ResimAdi;
            string adres;
            var userGet = userManager.GetUserByUserId(user.UserId);
            string onceki = userGet.ImageURL;
            if (file != null)
            {
                 ResimAdi = System.IO.Path.GetFileName(file.FileName);
                 adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                user.ImageURL = ResimAdi;
            }
            else
            {
                user.ImageURL = onceki;

            }
            if (ModelState.IsValid)
            {
                //db.Entry(user).State = EntityState.Modified;
                //db.SaveChanges();
                userManager.Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            User user = userManager.GetUserByUserId(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //User user = db.Users.Find(id);
            //db.Users.Remove(user);
            //db.SaveChanges();
            User user = userManager.GetUserByUserId(id);
            userManager.Delete(user);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}