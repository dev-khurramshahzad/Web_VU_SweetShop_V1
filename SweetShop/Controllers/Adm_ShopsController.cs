using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweetShop.Models;

namespace SweetShop.Controllers
{
    public class Adm_ShopsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Shops
        public ActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        // GET: Adm_Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Adm_Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adm_Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Shop shop, HttpPostedFileBase pic)
        {
            string img = Path.GetFileName(pic.FileName);
            string Ext = Path.GetExtension(img);
            Ext = Ext.ToLower();
            if (Ext == ".jpg" || Ext == ".png" || Ext == ".bmp" || Ext == ".jpeg" || Ext == ".tiff" || Ext == ".tif")
            {
                shop.Image = img;
                string StorePath = Path.Combine(Server.MapPath("~/Content/AppData"), img);
                pic.SaveAs(StorePath);
            }
            else
            {
                TempData["State"] = "error";
                TempData["Message"] = "Please select a Valid Picure.";
                return View(shop);
            }
            if (ModelState.IsValid)
            {
                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: Adm_Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Adm_Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Shop shop, HttpPostedFileBase pic)
        {
            if (pic!=null)
            {

                string img = Path.GetFileName(pic.FileName);
                string Ext = Path.GetExtension(img);
                Ext = Ext.ToLower();
                if (Ext == ".jpg" || Ext == ".png" || Ext == ".bmp" || Ext == ".jpeg" || Ext == ".tiff" || Ext == ".tif")
                {
                    shop.Image = img;
                    string StorePath = Path.Combine(Server.MapPath("~/Content/AppData"), img);
                    pic.SaveAs(StorePath);
                }
                else
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";
                    return View(shop);
                }
            }



            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Adm_Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Adm_Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
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
