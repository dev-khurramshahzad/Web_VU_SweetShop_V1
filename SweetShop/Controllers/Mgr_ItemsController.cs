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
    public class Mgr_ItemsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Items
        public ActionResult Index()
        {
            Shop shop = null;
            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }

            var items = db.Items.Where(x => x.ShopFID == shop.ShopID).Include(i => i.Category).Include(i => i.Shop);
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
        public ActionResult Create(Item item, HttpPostedFileBase pic)
        {
            string img = Path.GetFileName(pic.FileName);
            string Ext = Path.GetExtension(img);
            Ext = Ext.ToLower();
            if (Ext == ".jpg" || Ext == ".png" || Ext == ".bmp" || Ext == ".jpeg" || Ext == ".tiff" || Ext == ".tif")
            {
                item.Image1 = img;
                string StorePath = Path.Combine(Server.MapPath("~/Content/AppData"), img);
                pic.SaveAs(StorePath);
            }
            else
            {
                TempData["State"] = "error";
                TempData["Message"] = "Please select a Valid Picure.";
                return View(item);
            }

            Shop shop = null;
            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }

            item.ShopFID = shop.ShopID;


            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return Redirect("/Mgr_Items/");
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
        public ActionResult Edit(Item item, HttpPostedFileBase pic)
        {
            if (pic != null)
            {
                string img = Path.GetFileName(pic.FileName);
                string Ext = Path.GetExtension(img);
                Ext = Ext.ToLower();
                if (Ext == ".jpg" || Ext == ".png" || Ext == ".bmp" || Ext == ".jpeg" || Ext == ".tiff" || Ext == ".tif")
                {
                    item.Image1 = img;
                    string StorePath = Path.Combine(Server.MapPath("~/Content/AppData"), img);
                    pic.SaveAs(StorePath);
                }
                else
                {
                    TempData["State"] = "error";
                    TempData["Message"] = "Please select a Valid Picure.";
                    ViewBag.CatFID = new SelectList(db.Categories, "CatID", "Name", item.CatFID);
                    ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", item.ShopFID);
                    return View(item);
                }

            }

            Shop shop = null;
            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }

            item.ShopFID = shop.ShopID;


            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                                return Redirect("/Mgr_Items/");
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
                            return Redirect("/Mgr_Items/");
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
