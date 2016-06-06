using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;


namespace ToyWebsite.Controllers
{
    // Controls the display of individual and group product pages
    public class ProductController : Controller
    {

        // GET: Display
        public ActionResult Item(int anItemID)
        {
            StoreContext context = new StoreContext();
            Item item = (from i in context.Items
                         where i.itemID == anItemID
                         select i).Single();

            return View(item);
        }

        public ActionResult Category(int aCategoryID)
        {
            //Store items
            StoreContext context = new StoreContext();
            List<Item> items = (from i in context.Items
                                where i.categoryID == aCategoryID
                                select i).DefaultIfEmpty().ToList();

            /*
            //Store category name by creating a default item
            if(Object.Equals(items.First(), default(Item)))
            {
                Item tempItem = default(Item);
                Category tempCategory = (from c in context.Categories
                                          where c.categoryID == aCategoryID
                                          select c).FirstOrDefault();
           


                items.Clear();
                items.Add(tempItem);
            }
            
            ViewBag.categoryName = (from c in context.Categories
                                    where c.categoryID == aCategoryID
                                    select c).First().categoryName;
            */

            //If category is still default return error page
            return View(items);
            
        }

        /* Checks if an item is in the cart */
        [ChildActionOnly]
        public ActionResult CartStatus(int anItemID)
        {
            StoreContext context = new StoreContext();
            List<Cart> cartItems = (from s in context.Carts
                                    where s.userID == 1 && s.itemID == anItemID
                                    select s).DefaultIfEmpty().ToList();
            ViewBag.itemID = anItemID;

            return PartialView(cartItems);
        }

        /* Adds an item to the cart */
        [HttpPost]
        public ActionResult AddToCart(int anItemID)
        {
            StoreContext context = new StoreContext();
            context.Carts.Add(new Cart { itemID = anItemID, userID = 1 });
            context.SaveChanges();

            return RedirectToAction("Item", new { anItemID = anItemID });
        }

        [HttpPost]
        public void Example()
        {
            return;
        }

        //Deletes a cart object
        [HttpPost]
        public ActionResult ChangeItemQuantity(int anItemID, int quantityDifference)
        {
            
            StoreContext context = new StoreContext();
            List<Cart> removeItems;

            if(quantityDifference > 0)
            {
                for (int i = 0; i < quantityDifference; i++)
                {
                    context.Carts.Add(new Cart { itemID = anItemID, userID = 1 });
                }
            }
            else if (quantityDifference < 0)
            {
                quantityDifference = Math.Abs(quantityDifference);
                removeItems = (from c in context.Carts
                               where c.itemID == anItemID
                               select c).Take(quantityDifference).ToList();

                foreach (Cart x in removeItems)
                {
                    context.Carts.Remove(x);
                }
            }
            context.SaveChanges();
            
            return RedirectToAction("Item", new { anItemID = anItemID });
        }



    }
}