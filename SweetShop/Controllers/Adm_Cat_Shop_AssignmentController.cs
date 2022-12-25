using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweetShop.Models;

namespace SweetShop.Controllers
{
    public class Adm_Cat_Shop_AssignmentController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Cat_Shop_Assignment
        public ActionResult Index()
        {
            var cat_Shop_Assignment = db.Cat_Shop_Assignment.Include(c => c.Category).Include(c => c.Shop);
            return View(cat_Shop_Assignment.ToList());
        }

        // GET: Adm_Cat_Shop_Assignment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Shop_Assignment cat_Shop_Assignment = db.Cat_Shop_Assignment.Find(id);
            if (cat_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            return View(cat_Shop_Assignment);
        }

        // GET: Adm_Cat_Shop_Assignment/Create
        public ActionResult Create()
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name");
            return View();
        }

        // POST: Adm_Cat_Shop_Assignment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CatShopID,CatFID,ShopFID")] Cat_Shop_Assignment cat_Shop_Assignment)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Shop_Assignment.Add(cat_Shop_Assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", cat_Shop_Assignment.CatFID);
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", cat_Shop_Assignment.ShopFID);
            return View(cat_Shop_Assignment);
        }

        // GET: Adm_Cat_Shop_Assignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Shop_Assignment cat_Shop_Assignment = db.Cat_Shop_Assignment.Find(id);
            if (cat_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", cat_Shop_Assignment.CatFID);
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", cat_Shop_Assignment.ShopFID);
            return View(cat_Shop_Assignment);
        }

        // POST: Adm_Cat_Shop_Assignment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CatShopID,CatFID,ShopFID")] Cat_Shop_Assignment cat_Shop_Assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Shop_Assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", cat_Shop_Assignment.CatFID);
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", cat_Shop_Assignment.ShopFID);
            return View(cat_Shop_Assignment);
        }

        // GET: Adm_Cat_Shop_Assignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Shop_Assignment cat_Shop_Assignment = db.Cat_Shop_Assignment.Find(id);
            if (cat_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            return View(cat_Shop_Assignment);
        }

        // POST: Adm_Cat_Shop_Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Shop_Assignment cat_Shop_Assignment = db.Cat_Shop_Assignment.Find(id);
            db.Cat_Shop_Assignment.Remove(cat_Shop_Assignment);
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
