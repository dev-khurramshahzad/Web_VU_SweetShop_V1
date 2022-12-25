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
    public class Adm_ItemsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category);
            return View(items.ToList());
        }

        // GET: Adm_Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Adm_Items/Create
        public ActionResult Create()
        {
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name");
            return View();
        }

        // POST: Adm_Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,CatFID,SalePrice,CostPrice,MFGDate,EXPDate,Image1,Image2,Type,Quantity,Rating,Details,Status")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", item.CatFID);
            return View(item);
        }

        // GET: Adm_Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", item.CatFID);
            return View(item);
        }

        // POST: Adm_Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,CatFID,SalePrice,CostPrice,MFGDate,EXPDate,Image1,Image2,Type,Quantity,Rating,Details,Status")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", item.CatFID);
            return View(item);
        }

        // GET: Adm_Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Adm_Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
