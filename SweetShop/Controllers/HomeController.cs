using SweetShop.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.EnterpriseServices.CompensatingResourceManager;

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        private dbModel db = new dbModel();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Categories(int? id)
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Items(int? id)
        {
            var items = db.Items.ToList();
            if (id != null)
            {
                items.Where(x => x.CatFID == id).ToList();
            }
            return View(items);
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }
        public ActionResult AddtoCart(int id)
        {
            if (Session["Cart"] == null)
            {
                List<CartItem> Cart = new List<CartItem>();
                Cart.Add(new CartItem { item = db.Items.Find(id), quantity = 1 });

                Session["Cart"] = Cart;
            }

            else
            {
                List<CartItem> Cart = (List<CartItem>)Session["Cart"];
                int FoundItem = -1;
                for (int i = 0; i < Cart.Count; i++)
                {
                    if (Cart[i].item.ItemID == id)
                    {
                        FoundItem = i;
                    }

                }

                if (FoundItem == -1)
                {
                    Cart.Add(new CartItem { item = db.Items.Find(id), quantity = 1 });
                }
                else
                {
                    Cart[FoundItem].quantity++;
                }


                Session["Cart"] = Cart;
            }

            return RedirectToAction("ShoppingCart");
        }
        public ActionResult Remove(int id)
        {
            List<CartItem> Cart = (List<CartItem>)Session["Cart"];
            int FoundItem = -1;
            for (int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].item.ItemID == id)
                {
                    FoundItem = i;
                }
            }
            Cart.RemoveAt(FoundItem);

            Session["Cart"] = Cart;
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult QtyPlus(int id)
        {
            List<CartItem> Cart = (List<CartItem>)Session["Cart"];
            int FoundItem = -1;
            for (int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].item.ItemID == id)
                {
                    FoundItem = i;
                }
            }


            Cart[FoundItem].quantity++;

            Session["Cart"] = Cart;
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult QtyMinus(int id)
        {
            List<CartItem> Cart = (List<CartItem>)Session["Cart"];
            int FoundItem = -1;
            for (int i = 0; i < Cart.Count; i++)
            {
                if (Cart[i].item.ItemID == id)
                {
                    FoundItem = i;
                }
            }
            if (Cart[FoundItem].quantity > 1)
            {
                Cart[FoundItem].quantity--;
            }
            else
            {
                TempData["State"] = "error";
                TempData["Message"] = "Quantity cannot be less than 1";
                return RedirectToAction("ShoppingCart");

            }

            Session["Cart"] = Cart;
            return RedirectToAction("ShoppingCart");
        }
        public ActionResult Checkout(string method)
        {
            if (Session["Cart"] == null || ((List<CartItem>)Session["Cart"]).Count == 0)
            {
                TempData["State"] = "warning";
                TempData["Message"] = "Cart is Empty Please add an Item to checkout";
                return Redirect("/Home/ShoppingCart");
            }
            User user = null;
            if (Session["LoggedInUser"] != null)
            {
                user = (User)Session["LoggedInUser"];
            }
            else
            {
                TempData["State"] = "warning";
                TempData["Message"] = "You must be logged in to checkout.";

                return Redirect("/Home/Login?return_url=" + this.Request.RawUrl);
            }
            //ORDER SAVING ================================================================

            Order order = new Order()
            {
                UserFID = user.UserID,
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                Status = "Pending"
            };
            db.Orders.Add(order);
            db.SaveChanges();

            double total = 0;
            List<CartItem> Cart = (List<CartItem>)Session["Cart"];
            for (int i = 0; i < Cart.Count; i++)
            {
                total = total + (Cart[i].quantity * Cart[i].item.SalePrice);
                OrderDetail detail = new OrderDetail()
                {
                    OrderFID = db.Orders.Max(x => x.OrderID),
                    ItemFID = Cart[i].item.ItemID,
                    Quantity = Cart[i].quantity
                };
                db.OrderDetails.Add(detail);
                db.SaveChanges();


                // Reducing the Quantity=================================================

                db.Items.Find(Cart[i].item.ItemID).Quantity = db.Items.Find(Cart[i].item.ItemID).Quantity - Cart[i].quantity;
                db.SaveChanges();
            }

            string ConfirmedOrderID = db.Orders.Max(x => x.OrderID).ToString();


            //EMPTY CART======================================================================
            Session["Cart"] = null;


            if (method == "COD")
            {
                return Redirect("/Home/OrderConfirmed/" + ConfirmedOrderID);

            }
            else
            {
                return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&amount=" + total / 220 + "&business=JanjuaTailors@Shop.com&item_name=ToyLand&return=https://localhost:44300/Home/OrderConfirmed/" + ConfirmedOrderID);

            }


        }
        public ActionResult OrderConfirmed(int? id)
        {
            if (id == null)
            {
                id = db.Orders.Max(x => x.OrderID);
            }

            TempData["State"] = "success";
            TempData["Message"] = "Order has confirmed. It will be delivered soon order details are as under";



            var order = db.Orders.Find(id);
            ViewBag.Cart = db.OrderDetails.Where(x => x.OrderFID == order.OrderID).ToList();

            return View(order);
        }

        public ActionResult Login(string return_url)
        {
            ViewBag.return_url = return_url;
            return View();
        }
        public ActionResult LoginVerify(string email, string password, string type, string return_url)
        {
            if (return_url == null)
            {
                return_url = "/Home/";
            }
            var check = db.Users.FirstOrDefault(x => x.Email == email && x.Password == password && x.Type == type);
            if (check == null)
            {
                return Content("<script>alert('Email or Password Incorrect....');window.history.back();</script>");
            }
            else
            {
                if (type == "Customer")
                {
                    Session["LoggedInUser"] = check;
                    return Redirect(return_url);
                }
                if (type == "Manager")
                {
                    Session["LoggedInManager"] = check;
                    return Redirect("/Home/Manager");
                }
                if (type == "Admin")
                {
                    return Redirect("/Home/Admin");
                }
                return Redirect("/Home/Index");
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult CreateData(string name, string phone, string address, string email, string password, string cpassword, string type)
        {
            if (password != cpassword)
            {
                return Content("<script>alert('Passwords do not match...');window.history.back();</script>");
            }

            var check = db.Users.FirstOrDefault(x => x.Email == email && x.Type == type);
            if (check != null)
            {
                return Content("<script>alert('This email with same role is already registered....');window.history.back();</script>");

            }

            var c = new User()
            {
                Name = name,
                Phone = phone,
                Address = address,
                Email = email,
                Password = password,
                Type = type,
                Status = "Active",
                Details = "N/A",
                Image = "N/A"

            };

            db.Users.Add(c);
            db.SaveChanges();

            return Redirect("/Home/Login");
        }


        public ActionResult Logout()
        {
            Session["LoggedInUser"] = null;
            Session["LoggedInManager"] = null;

            return Redirect("/Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}