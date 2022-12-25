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
    public class Adm_FeedbacksController : Controller
    {
        private dbModel db = new dbModel();

        // GET: Adm_Feedbacks
        public ActionResult Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.Shop).Include(f => f.User);
            return View(feedbacks.ToList());
        }

        // GET: Adm_Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Adm_Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name");
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: Adm_Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedBackID,ShopFID,UserFID,FeedbackType,Message,Date,Time,Status")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", feedback.ShopFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", feedback.UserFID);
            return View(feedback);
        }

        // GET: Adm_Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", feedback.ShopFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", feedback.UserFID);
            return View(feedback);
        }

        // POST: Adm_Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedBackID,ShopFID,UserFID,FeedbackType,Message,Date,Time,Status")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShopFID = new SelectList(db.Shops, "ShopID", "Name", feedback.ShopFID);
            ViewBag.UserFID = new SelectList(db.Users, "UserID", "Name", feedback.UserFID);
            return View(feedback);
        }

        // GET: Adm_Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Adm_Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
