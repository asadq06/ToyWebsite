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
        public ActionResult Index()
        {
            
            StoreContext context = new StoreContext();
            List<Item> topSellingItems = (from i in context.Items
                            
                             select i).ToList();
            
            return View(topSellingItems);
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