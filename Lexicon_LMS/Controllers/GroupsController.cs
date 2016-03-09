using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;


namespace Lexicon_LMS
{
    [Authorize(Roles = "Teacher")]
    public class GroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Groups
        public ActionResult Index()
        {
            string userName = User.Identity.Name;
            var activeUser = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();
            //string activeUser = User.Identity.ToString();
            string fullName = FindTeacherName(userName); //anropar metod som utifrån mailadress(userName) returnerar för- och efternamn på lärare.
            //var firstName = (from u in db.Users
            //                 where u.UserName == userName
            //                 select u.FirstName).FirstOrDefault();

            //var lastName = (from u in db.Users
            //               where u.UserName == userName
            //               select u.LastName).FirstOrDefault();

            ////string fullName = firstName + " " + lastName;
            //string fullName = firstName + " " + lastName;




            //var _firstName = db.Users.Where(u => u.UserName == userName);
            //var _lastName = db.Users.Where(u => u.UserName == userName);

            //var iD = db.Users.Where(i => i.Email == userName);
            //var iD = (from p in db.Users where p.Email == userName select p.Id).FirstOrDefault();
            //var user = db.Users.Where(u => u.Id == iD).FirstOrDefault().Roles.FirstOrDefault().;

            // User.IsInRole("Teacher");
            //User.IsInRole("Student");

            //var roleId = from r in db. where r. == iD select r.Id;
            //var rId = roleId;

            //int userId = db.
            //if (User.Identity.Name == "oscar.jakobsson@lexicon.se")

            ViewBag.TeacherName = fullName;
            ViewBag.TeacherId = User.Identity.Name;
            //return View();
            return View(db.Groups.Where(g => g.TeacherId == activeUser.Id).OrderBy(d => d.StartDate));
        }


        // GET: All Groups
        public ActionResult ListAllGroups()
        {
            string userName = User.Identity.Name;
            string fullName = FindTeacherName(userName); //anropar metod som utifrån mailadress(userName) returnerar för- och efternamn på lärare.
            // var activeUser = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();
            var activeUserId = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();

            //var activeUserId = (from u in db.Users
            //                    where u.UserName == userName
            //                    select u.Id).FirstOrDefault();



            //var firstName = (from u in db.Users
            //                 where u.UserName == userName
            //                 select u.FirstName).FirstOrDefault();

            //var lastName = (from u in db.Users
            //                where u.UserName == userName
            //                select u.LastName).FirstOrDefault();

            // fullName = firstName + " " + lastName;

            //ViewBag.TeacherName = fullName;
            ViewBag.TeacherId = activeUserId;

            //ViewData["AllUsers"] = db.Users;
            //ViewBag.Teacher = User.Identity.Name;


            return View(db.Groups.OrderBy(d => d.StartDate));

        }



        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupName = group.Name;

            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            //ViewBag.All = db.Groups.Select(h => new SelectListItem
            //{
            //    Value = h.TeacherId.ToString(),
            //});
            //return View();
           // ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name");
           
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.GroupId == null), "Id", "FirstName");
            //ViewBag.GroupId = new SelectList(db.Users.Where(u => u.GroupId == null), "GroupId", "FirstName");

            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name,TeacherId,Description,StartDate,EndDate")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Users.Where(u => u.GroupId == null), "Id", "FirstName");

            return View(group);
        }


        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            string userName = User.Identity.Name;
            string fullName = FindTeacherName(userName);
            ViewBag.TeacherName = fullName;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = group.TeacherId;

            return View(group);
        }



        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,TeacherId, Teacher, Name,Description,StartDate,EndDate")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        //Metod som tar emot mailadress(userName) för inloggad lärare och returnerar för- och efternamn.
        private string FindTeacherName(string name)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == name);
            return user.FirstName + " " + user.LastName;



            //var firstName = (from u in db.Users
            //                 where u.UserName == name
            //                 select u.FirstName).FirstOrDefault();

            //var lastName = (from u in db.Users
            //                where u.UserName == name
            //                select u.LastName).FirstOrDefault();

            //string fullName = firstName + " " + lastName;
            //return fullName;
        }
    }
}
