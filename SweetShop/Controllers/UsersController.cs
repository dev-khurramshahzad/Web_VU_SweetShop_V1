using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SweetShop.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}