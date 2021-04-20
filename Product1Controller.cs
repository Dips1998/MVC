using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Nimap.Models;

namespace MVC_Nimap.Controllers
{
    public class Product1Controller : Controller
    {
        private nimapEntities db = new nimapEntities();

        // GET: Product1
        public ActionResult Index()
        {
            return View(db.Product1.ToList());
        }

        // GET: Product1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // GET: Product1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Product1.Add(product1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product1);
        }

        // GET: Product1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Product1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,CategoryId,CategoryName")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product1);
        }

        // GET: Product1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Product1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product1 product1 = db.Product1.Find(id);
            db.Product1.Remove(product1);
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
