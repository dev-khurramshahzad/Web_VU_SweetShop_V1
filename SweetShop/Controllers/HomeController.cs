using SweetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        private dbModel db= new dbModel();
        public static int shopId = 0;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shops()
        {
            var shops = db.Shops.ToList();
            return View(shops);
        }

        public ActionResult Categories(int? id)
        {
           
            List<Category> categories = db.Categories.ToList();
            if (id != null)
            {
                shopId = (int)id;
                categories = db.Categories.Where(x => x.Cat_Shop_Assignment.Any(y => y.ShopFID == id)).ToList();
            }


            return View(categories);
        }

        public ActionResult Items(int? id)
        {
            List<Item> items = db.Items.ToList();
            if (shopId !=0)
            {
                items = db.Items.Where(x => x.Item_Shop_Assignment.Any(y => y.ShopID == shopId)).ToList();

            }

            if (id!=null)
            {
                items = items.Where(x => x.CatFID == id).ToList();
            }

            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}