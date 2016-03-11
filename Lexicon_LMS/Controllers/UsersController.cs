using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Lexicon_LMS.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index(int? groupId)
        {
            var ActiveUser = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();

            if (groupId != null)
            {
                if (User.IsInRole("Teacher"))
                {
                    var users = db.Users.Where(u => u.GroupId == groupId);
                    ViewBag.GroupName = users.FirstOrDefault().Group.Name;
                    ViewBag.Group_Id = groupId;
                    return View(users.ToList());
                }
                else
                {
                    var ActiveGroup = db.Groups.Where(g => g.GroupId == ActiveUser.GroupId);
                    ViewBag.GroupName = ActiveGroup.First().Name;
                    ViewBag.Group_Id = ActiveGroup.First().GroupId;
                    var users = db.Users.Where(u => u.GroupId == ActiveUser.GroupId);
                    return View(users.ToList());
                }
            }
            else
            {
                if (ActiveUser.GroupId != null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    if (User.IsInRole("Teacher"))
                    {
                        ViewBag.Group_Id = groupId;
                        var users = db.Users.Where(u => u.GroupId == groupId);
                        return View(users.ToList());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_Id = applicationUser.GroupId;
            return View(applicationUser);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupId,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_Id = applicationUser.GroupId;
            return View(applicationUser);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,GroupId,FirstName,LastName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<ApplicationUser>(db);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = db.Users.Where(u => u.Id == applicationUser.Id).FirstOrDefault();
                var groupId = user.GroupId;
                user.FirstName = applicationUser.FirstName;
                user.LastName = applicationUser.LastName;
                user.Email = applicationUser.Email;
                user.UserName = user.Email;


                userManager.Update(user);
                db.SaveChanges();

                return RedirectToAction("Index", new { GroupId = groupId });
            }
            return View(applicationUser);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_Id = applicationUser.GroupId;
            return View(applicationUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            var groupId = applicationUser.GroupId;
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index", new { GroupId = groupId });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
