using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            //Check if user already exists
            if ((from u in context.Users
                 where u.userName == aUser.userName
                 select u).Any())
            {
                TempData["errorMessage"] = "Username taken.";
                return RedirectToAction("Register");
            }

            //Check if email already exists
            if ((from u in context.Users
                 where u.userEmail == aUser.userEmail
                 select u).Any())
            {
                TempData["errorMessage"] = "User with that email address already exists.";
                return RedirectToAction("Register");
            }

            //aUser.userPassword = HashPassword(aUser.userPassword);

            //Adds new user and sets current user to this user
            context.Users.Add(aUser);
            context.SaveChanges();
            Session["GuestUser"] = false;
            Session["UserID"] = aUser.userID;

            return RedirectToAction("RegistrationComplete");
        }

        //Notifies the user registration is complete 
        public ActionResult RegistrationComplete()
        {
            return View();
        }

        //This controls the login page
        public ActionResult LogIn()
        {
            if (Session["GuestUser"] == null || (bool)Session["GuestUser"] == true)
                return View();
            else
                return RedirectToAction("LogInComplete");
        }

        //This checks if the log in was successful
        public ActionResult LogInCheck(User aUser)
        {
            StoreContext context = new StoreContext();

            List<User> matchingUsers = (from u in context.Users
                                    where u.userName == aUser.userName && u.userPassword == aUser.userPassword
                                    select u).ToList();

            //Returns true if the user is not in the DB
            if (matchingUsers.Any())
            {
                //There is an error if there are multiple matching users
                Session["GuestUser"] = false;
                Session["UserID"] = matchingUsers.Single().userID;

                return RedirectToAction("LogInComplete");
            }
            else
            {
                TempData["errorMessage"] = "Username or password incorrect.";
                return RedirectToAction("LogIn");
            }
        }

        //Redirection to this page means successfull login
        public ActionResult LogInComplete()
        {
            if (Session["GuestUser"] != null && (bool)Session["GuestUser"] == false)
            {

                return View();
            }
            else
                return RedirectToAction("LogIn");
        }

        //Signs user our
        public ActionResult SignOut()
        {
            Session["GuestUser"] = true;
            Session["UserID"] = 0;

            return RedirectToAction("Index", "Home");
;        }
        private const string _alg = "HmacSHA256";
        private const string _salt = "rz8LuOtFBXphj9WQfvFh"; // Generated at https://www.random.org/strings

        public static string GenerateToken(string username, string password, string ip, string userAgent, long ticks)
        {
            string hash = string.Join(":", new string[] { username, ip, userAgent, ticks.ToString() });
            string hashLeft = "";
            string hashRight = "";

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));

                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { username, ticks.ToString() });
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }






    }
}