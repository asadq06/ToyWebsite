using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;

namespace ToyWebsite.Controllers
{
    public class HomeController : Controller
    {
        [LoggingFilter]
        public ActionResult Index()
        {
            StoreContext context = new StoreContext();
            List<Item> topSellingItems = (from i in context.Items
                             select i).ToList();
            
            return View(topSellingItems);
        }
    }
}