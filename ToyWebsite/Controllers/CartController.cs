using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;

namespace ToyWebsite.Controllers
{
    //Conrols the cart page
    public class CartController : Controller
    {
        // GET: Cart
        [LoggingFilter]
        public ActionResult Index()
        {
            //Retrieve all the information in the carts for the user
            StoreContext context = new StoreContext();
            int sessionUserID = (int)Session["UserID"];
            ILookup<int, Cart> cartItems = (from i in context.Carts
                                            where i.userID == sessionUserID
                                            select i).ToLookup(x => x.itemID);


            return View(cartItems);
        }

        /*Removes all items of the same itemID in a cart*/
        [HttpPost]
        [LoggingFilter]
        public ActionResult RemoveItem(int anItemID)
        {
            StoreContext context = new StoreContext();
            List<Cart> removeItems = (from c in context.Carts
                                      where c.itemID == anItemID
                                      select c).ToList();

            foreach (Cart x in removeItems)
            {
                context.Carts.Remove(x);
            }
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [LoggingFilter]
        public ActionResult IncrementItem(int anItemID)
        {
            StoreContext context = new StoreContext();
            int sessionUserID = (int)Session["UserID"];
            if ((from c in context.Carts
                 where c.itemID == anItemID && c.userID == sessionUserID
                 select c).Count() < 10)
            {
                context.Carts.Add(new Cart { itemID = anItemID, userID = sessionUserID });
                context.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [LoggingFilter]
        public ActionResult DecrementItem(int anItemID)
        {
            StoreContext context = new StoreContext();
            int sessionUserID = (int)Session["UserID"];
            context.Carts.Remove((from c in context.Carts
                                  where c.itemID == anItemID && c.userID == sessionUserID
                                  select c).First());
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        //Merges two carts together
        public static void MergeGuestCart(int guestUserID, int registeredUserID)
        {
            StoreContext context = new StoreContext();
            User registeredUser = (from u in context.Users
                                   where u.userID == registeredUserID
                                   select u).Single();
            User guestUser = (from u in context.Users
                              where u.userID == guestUserID
                              select u).Single();


            //Find every item in the cart belonging to guest user
            List<Cart> guestCartItems = (from c in context.Carts
                                         where c.userID == guestUser.userID
                                         select c).ToList();

            //Change all values
            foreach(Cart c in guestCartItems)
            {
                c.userID = registeredUser.userID;
            }

            //Save changes
            context.SaveChanges();
        }
    }
}