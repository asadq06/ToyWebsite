using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToyWebsite.DAL;
using ToyWebsite.Models;

namespace ToyWebsite.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User aUser)
        {
            StoreContext context = new StoreContext();
            context.Users.Add(aUser);
            context.SaveChanges();

            return RedirectToAction("RegistrationComplete");
        }

        public ActionResult RegistrationComplete()
        {
            return View();
        }

        //This controls the login page
        public ActionResult LogIn()
        {
            return View();
        }
        
        //This sets who the current user is
        public void CurrentUser(User aUser)
        {

        }




        


    }
}