using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class CartController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Cart
        public ActionResult Index()
        {

            return View(getCartListWithBooks());
        }

        private List<Book> getCartListWithBooks()
        {
           // Cart cart = new Cart();

            List<Book> cart = new List<Book>();

            if (Session["cart"] != null)
            {
              var list = (List<BookCopy>)Session["cart"];
                foreach (var book in list)
                {
                    cart.Add(db.Books.Where(x => x.BookID == book.BookID).First());

                }
            }
            return cart;

        }
        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            Cart cart = new Cart();

            if (Session["cart"] != null)
            {
                cart.cartList = (List<BookCopy>)Session["cart"];
            }

            var item = cart.cartList.Where(x => x.BookID == id).FirstOrDefault();
            cart.cartList.Remove(item);

            Session["cart"] = cart.cartList;

            return RedirectToAction("Index", "Cart");
        }

        // POST: Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
