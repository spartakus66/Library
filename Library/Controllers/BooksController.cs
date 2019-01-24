using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using Library.Models;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Books
        public ActionResult Index(string searchString, string searchRadioButton)
        {
            var books = db.Books.Include(b => b.Publisher).OrderBy(n => n.Title).ToList();

            
            if (!String.IsNullOrEmpty(searchString))
            {
                if (searchRadioButton.Equals("Title"))
                {
                    books = books.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
                if (searchRadioButton.Equals("ISBN"))
                {
                    books = books.Where(s => s.ISBN.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
            }

            return View(books);
        }
       
        // GET: Books/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,ISBN,Title,Destription,PublisherID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,ISBN,Title,Destription,PublisherID")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize(Roles = "Administrator, Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Borrow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book.BookCopies);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        public ActionResult Borrow([Bind(Include = "BookID,ISBN,Title,Destription,PublisherID")] Book book)
        {

            return View(book.BookCopies);


            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Borrow");
            }
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName", book.PublisherID);
            return View(book);
        }
        
        public ActionResult BorrowAccepted(int? id)
        {
           
            BookCopy bookCopy = db.BookCopies.Find(id);
            if (bookCopy == null)
            {
                return HttpNotFound();
            }
            
            addToCart(bookCopy);

            return View(getCartList());
        }

        [Authorize]
        [HttpPost]
        public ActionResult BorrowAccepted([Bind(Include = "BookID,ISBN,Title,Destription,PublisherID")] Book book)
        {
            return View(getCartList());
        }

        [HttpPost]
        public string Search(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        [HttpPost]
        public string Search(string searchString)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        private List<BookCopy> getCartList()
        {
            Cart cart = new Cart();

            if (Session["cart"] != null)
            {
                cart.cartList = (List<BookCopy>)Session["cart"];
            }

            return cart.cartList;

        }

        private void addToCart(BookCopy bookCopy)
        {
            List<BookCopy> listBookCopies = new List<BookCopy>();
            if (Session["cart"] != null)
            {
                listBookCopies = (List<BookCopy>)Session["cart"];
            }
            listBookCopies.Add(bookCopy);
            Session["cart"] = listBookCopies;

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
