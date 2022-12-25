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
    public class Adm_Item_Shop_AssignmentController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Item_Shop_Assignment
        public ActionResult Index()
        {
            var item_Shop_Assignment = db.Item_Shop_Assignment.Include(i => i.Item).Include(i => i.Shop);
            return View(item_Shop_Assignment.ToList());
        }

        // GET: Adm_Item_Shop_Assignment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Shop_Assignment item_Shop_Assignment = db.Item_Shop_Assignment.Find(id);
            if (item_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            return View(item_Shop_Assignment);
        }

        // GET: Adm_Item_Shop_Assignment/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.ShopID = new SelectList(db.Shops, "ShopID", "Name");
            return View();
        }

        // POST: Adm_Item_Shop_Assignment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemShopID,ItemID,ShopID")] Item_Shop_Assignment item_Shop_Assignment)
        {
            if (ModelState.IsValid)
            {
                db.Item_Shop_Assignment.Add(item_Shop_Assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", item_Shop_Assignment.ItemID);
            ViewBag.ShopID = new SelectList(db.Shops, "ShopID", "Name", item_Shop_Assignment.ShopID);
            return View(item_Shop_Assignment);
        }

        // GET: Adm_Item_Shop_Assignment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Shop_Assignment item_Shop_Assignment = db.Item_Shop_Assignment.Find(id);
            if (item_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", item_Shop_Assignment.ItemID);
            ViewBag.ShopID = new SelectList(db.Shops, "ShopID", "Name", item_Shop_Assignment.ShopID);
            return View(item_Shop_Assignment);
        }

        // POST: Adm_Item_Shop_Assignment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemShopID,ItemID,ShopID")] Item_Shop_Assignment item_Shop_Assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_Shop_Assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", item_Shop_Assignment.ItemID);
            ViewBag.ShopID = new SelectList(db.Shops, "ShopID", "Name", item_Shop_Assignment.ShopID);
            return View(item_Shop_Assignment);
        }

        // GET: Adm_Item_Shop_Assignment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_Shop_Assignment item_Shop_Assignment = db.Item_Shop_Assignment.Find(id);
            if (item_Shop_Assignment == null)
            {
                return HttpNotFound();
            }
            return View(item_Shop_Assignment);
        }

        // POST: Adm_Item_Shop_Assignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item_Shop_Assignment item_Shop_Assignment = db.Item_Shop_Assignment.Find(id);
            db.Item_Shop_Assignment.Remove(item_Shop_Assignment);
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
