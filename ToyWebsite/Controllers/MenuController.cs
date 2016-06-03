using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;

namespace ToyWebsite.Controllers
{
    public class MenuController : Controller
    {
        [ChildActionOnly]
        public ActionResult CategoryDropdown()
        {
            StoreContext context = new StoreContext();
            //List<Category> categories = context.Categories.ToList();

            List<Category> categories = (from s in context.Categories
                                         orderby s.categoryName
                                         select s).ToList();

            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult CartQuantity()
        {

            return PartialView(2);
        }
    }
}