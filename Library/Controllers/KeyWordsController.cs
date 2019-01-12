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
    public class KeyWordsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: KeyWords
        public ActionResult Index()
        {
            return View(db.KeyWords.ToList());
        }

        // GET: KeyWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyWord keyWord = db.KeyWords.Find(id);
            if (keyWord == null)
            {
                return HttpNotFound();
            }
            return View(keyWord);
        }

        // GET: KeyWords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KeyWords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KeyWordID,KeyWordName")] KeyWord keyWord)
        {
            if (ModelState.IsValid)
            {
                db.KeyWords.Add(keyWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keyWord);
        }

        // GET: KeyWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyWord keyWord = db.KeyWords.Find(id);
            if (keyWord == null)
            {
                return HttpNotFound();
            }
            return View(keyWord);
        }

        // POST: KeyWords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KeyWordID,KeyWordName")] KeyWord keyWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keyWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyWord);
        }

        // GET: KeyWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KeyWord keyWord = db.KeyWords.Find(id);
            if (keyWord == null)
            {
                return HttpNotFound();
            }
            return View(keyWord);
        }

        // POST: KeyWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KeyWord keyWord = db.KeyWords.Find(id);
            db.KeyWords.Remove(keyWord);
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
