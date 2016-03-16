using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;
using System.IO;

namespace Lexicon_LMS
{
    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Documents
        public ActionResult Index(int? gid, int? cid, int? aid)
        {
            var documents = db.Documents.Include(d => d.Activity).Include(d => d.ApplicationUser).Include(d => d.Course).Include(d => d.Group);
            var docs = documents.Where(d => d.CourseId == cid && d.GroupId == gid && d.ActivityId == aid);
            return View(docs.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create(int? gId, int? cId, int? aId)
        {
            //ViewBag.AId = new SelectList(db.Activities, "ActivityId", "Type");
            //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            //ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name");
            Document document = new Document();
            document.ActivityId = aId;
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            document.CourseId = cId;
            document.GroupId = gId;
            return View(document);
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentId,ApplicationUserId,GroupId,CourseId,ActivityId,Title,FileName,Description,TimeStamp")] Document document, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
 
                if (upload != null && upload.ContentLength > 0)
                {
                //    var _document = new Document
                //    {
                //        //upload.
                //    };
                    //string str = Path.Combine(Server.MapPath("~/LMS_Documents"),System.IO.Path.GetFileName(upload.FileName));
                    document.FileName = System.IO.Path.GetFileName(upload.FileName);
                    upload.SaveAs(Path.Combine(Server.MapPath("~/LMS_Documents"), upload.FileName));
                    //course.Documents = new List<Document>();
                    //course.Documents.Add(document);
                }
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index", new { gId = document.GroupId, cId = document.CourseId, aId = document.ActivityId });
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "Type", document.ActivityId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", document.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", document.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", document.GroupId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "Type", document.ActivityId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", document.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", document.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", document.GroupId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentId,ApplicationUserId,GroupId,CourseId,ActivityId,Title,FileName,Description,TimeStamp")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { gId = document.GroupId, cId = document.CourseId, aId = document.ActivityId });
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "Type", document.ActivityId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", document.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", document.CourseId);
            ViewBag.GroupId = new SelectList(db.Groups, "GroupId", "Name", document.GroupId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
    }
}
