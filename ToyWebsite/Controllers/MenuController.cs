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
            StoreContext context = new StoreContext();
            int cartCount = (from s in context.Carts
                             where s.userID == 1
                             select s).Count();

            return PartialView(cartCount);
        }

        [ChildActionOnly]
        public ActionResult UserOptions()
        {
            StoreContext context = new StoreContext();
            User aUser;
            int currentUserID;
            if(Session["GuestUser"] == null || (bool)Session["GuestUser"] == true)
            {
                aUser = default(User);
            }
            else
            {
                currentUserID = (int)Session["UserID"];
                aUser = (from u in context.Users
                         where u.userID == currentUserID
                         select u).Single();
            }



            return PartialView(aUser);
        }

    }
}