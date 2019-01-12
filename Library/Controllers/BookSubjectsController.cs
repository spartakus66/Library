using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Biblioteka.Models;

namespace Library.Controllers
{
    public class BookSubjectsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: BookSubjects
        public ActionResult Index()
        {
            var bookSubjects = db.BookSubjects.Include(b => b.Book).Include(b => b.Subject);
            return View(bookSubjects.ToList());
        }

        // GET: BookSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSubject bookSubject = db.BookSubjects.Find(id);
            if (bookSubject == null)
            {
                return HttpNotFound();
            }
            return View(bookSubject);
        }

        // GET: BookSubjects/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title");
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: BookSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookSubjectID,BookID,SubjectID")] BookSubject bookSubject)
        {
            if (ModelState.IsValid)
            {
                db.BookSubjects.Add(bookSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookSubject.BookID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", bookSubject.SubjectID);
            return View(bookSubject);
        }

        // GET: BookSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSubject bookSubject = db.BookSubjects.Find(id);
            if (bookSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookSubject.BookID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", bookSubject.SubjectID);
            return View(bookSubject);
        }

        // POST: BookSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookSubjectID,BookID,SubjectID")] BookSubject bookSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", bookSubject.BookID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", bookSubject.SubjectID);
            return View(bookSubject);
        }

        // GET: BookSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookSubject bookSubject = db.BookSubjects.Find(id);
            if (bookSubject == null)
            {
                return HttpNotFound();
            }
            return View(bookSubject);
        }

        // POST: BookSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookSubject bookSubject = db.BookSubjects.Find(id);
            db.BookSubjects.Remove(bookSubject);
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
