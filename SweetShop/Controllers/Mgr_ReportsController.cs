using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweetShop.Models;
using SweetShop.ViewModels;

namespace SweetShop.Controllers
{
    public class Mgr_ReportsController : Controller
    {
        private dbModel db = new dbModel();
        public Shop shop = null;

       


        public ActionResult Stock()
        {
            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }
            return View(db.Items.Where(x=>x.ShopFID == shop.ShopID).ToList());

        }


        // GET: Admin_Orders

        public ActionResult Index(OrderSearchModel appSearch)
        {
            IQueryable<Order> result = db.Orders.AsQueryable();

            if (appSearch != null)
            {

                if (appSearch.Customer != null && appSearch.Customer != "")
                    result = result.Where(x => x.User.Name.Contains(appSearch.Customer));

                if (appSearch.Status != null && appSearch.Status != "--Select Order Status--")
                    result = result.Where(x => x.Status == appSearch.Status);

                if (appSearch.DateTo.HasValue)
                    result = result.Where(x => x.Date >= appSearch.DateFrom);

                if (appSearch.DateFrom.HasValue)
                    result = result.Where(x => x.Date <= appSearch.DateTo);
            }

            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }

            ViewBag.Orders = result.Where(x=>x.OrderDetails.All(y=>y.Item.ShopFID == shop.ShopID)).ToList();
            return View();
        
        }

        public ActionResult PLSReport()
        {
            if (Session["LoggedInManager"] != null)
            {
                User manager = (User)Session["LoggedInManager"];
                shop = db.Shops.Find(manager.ShopFID);
            }

            var prods = db.OrderDetails.Where(x=>x.Item.ShopFID == shop.ShopID);
            return View(prods);
        }



        public ActionResult OrderDetails(int id)
        {
            return View(db.OrderDetails.Where(x => x.OrderFID == id).ToList());
        }



        // GET: Admin_Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


        // GET: Admin_Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Pending(int id)
        {

            db.Orders.Find(id).Status = "Pending";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Waiting(int id)
        {

            db.Orders.Find(id).Status = "Waiting";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delivered(int id)
        {

            db.Orders.Find(id).Status = "Delivered";
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Ready(int id)
        {

            db.Orders.Find(id).Status = "Ready";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Cancelled(int id)
        {

            db.Orders.Find(id).Status = "Cancelled";
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
