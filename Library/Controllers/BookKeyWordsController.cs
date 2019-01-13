using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class BookKeyWordsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: BookKeyWords
        public ActionResult Index()
        {
            var bookKeyWords = db.BookKeyWords.Include(b => b.BookCopy).Include(b => b.KeyWord);
            return View(bookKeyWords.ToList());
        }

        // GET: BookKeyWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeyWord bookKeyWord = db.BookKeyWords.Find(id);
            if (bookKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(bookKeyWord);
        }

        // GET: BookKeyWords/Create
        public ActionResult Create()
        {
            ViewBag.BookCopyID = new SelectList(db.BookCopies, "BookCopyID", "BookCopyID");
            ViewBag.KeyWordID = new SelectList(db.KeyWords, "KeyWordID", "KeyWordName");
            return View();
        }

        // POST: BookKeyWords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookKeyWordID,BookCopyID,KeyWordID")] BookKeyWord bookKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.BookKeyWords.Add(bookKeyWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookCopyID = new SelectList(db.BookCopies, "BookCopyID", "BookCopyID", bookKeyWord.BookCopyID);
            ViewBag.KeyWordID = new SelectList(db.KeyWords, "KeyWordID", "KeyWordName", bookKeyWord.KeyWordID);
            return View(bookKeyWord);
        }

        // GET: BookKeyWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeyWord bookKeyWord = db.BookKeyWords.Find(id);
            if (bookKeyWord == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookCopyID = new SelectList(db.BookCopies, "BookCopyID", "BookCopyID", bookKeyWord.BookCopyID);
            ViewBag.KeyWordID = new SelectList(db.KeyWords, "KeyWordID", "KeyWordName", bookKeyWord.KeyWordID);
            return View(bookKeyWord);
        }

        // POST: BookKeyWords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookKeyWordID,BookCopyID,KeyWordID")] BookKeyWord bookKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookKeyWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookCopyID = new SelectList(db.BookCopies, "BookCopyID", "BookCopyID", bookKeyWord.BookCopyID);
            ViewBag.KeyWordID = new SelectList(db.KeyWords, "KeyWordID", "KeyWordName", bookKeyWord.KeyWordID);
            return View(bookKeyWord);
        }

        // GET: BookKeyWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookKeyWord bookKeyWord = db.BookKeyWords.Find(id);
            if (bookKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(bookKeyWord);
        }

        // POST: BookKeyWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookKeyWord bookKeyWord = db.BookKeyWords.Find(id);
            db.BookKeyWords.Remove(bookKeyWord);
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
