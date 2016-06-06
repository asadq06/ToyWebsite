using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;

namespace ToyWebsite.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Product(int itemID)
        {
            StoreContext context = new StoreContext();
            Item item = (from i in context.Items
                         where i.itemID == itemID
                         select i).Single();

            return View(item);
        }

        public ActionResult Category(int categoryID)
        {
            //Store items
            StoreContext context = new StoreContext();
            List<Item> items = (from i in context.Items
                         where i.categoryID == categoryID
                         select i).ToList();

            //Store category name
            ViewBag.categoryName = (from i in context.Categories
                                    where i.categoryID == categoryID
                                    select i).Single().categoryName;

            return View(items);
            
        }
    }
}