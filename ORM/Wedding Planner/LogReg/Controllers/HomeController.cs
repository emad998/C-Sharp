using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogReg.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        private LogRegContext db;
        public HomeController(LogRegContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("/register")]
        public IActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                // if Any already user exists that matches the email
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "is taken");
                }
            }

            if (ModelState.IsValid == false)
            {
                // To display the custom error message above IF it was added, OR to display the other validation errors
                return View("Index");
            }

            // hash pw
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("UserName", newUser.FirstName);
            return RedirectToAction("Success", "Home");
        }

        [HttpGet("/success")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AllWeddings = db.Weddings
            .Include(wed => wed.Guests)
            .ToList();

            ViewBag.LoggedUser = (int)HttpContext.Session.GetInt32("UserId");

            return View("Success");
        }

        // [HttpGet("/login")]
        // public IActionResult LoginPage()
        // {
        //     return View("LoginPage");
        // }


        [HttpPost("/login")]
        public IActionResult Login(LoginUser loginUser)
        {
            // a vague error message should be used so we don't reveal to potential hackers if the email is registered in our db or not
            // string genericErrMsg = "invalid credentials";

            if (ModelState.IsValid == false)
            {
                // display validation errors
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if (dbUser == null)
            {
                // ModelState.AddModelError("LoginEmail", genericErrMsg);
                ModelState.AddModelError("LoginEmail", "Email not found");
                return View("Index");
            }

            // user was found b/c above return did not happen
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            // right click the PasswordVerificationResult and go to definition for more info
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompareResult == 0)
            {
                // ModelState.AddModelError("LoginEmail", genericErrMsg);
                ModelState.AddModelError("LoginEmail", "wrong password");
                return View("Index");
            }

            // no returns happened, everything is good
            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            HttpContext.Session.SetString("UserName", dbUser.FirstName);
            return RedirectToAction("Success", "Home");
        }


        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }



        [HttpGet("/newWedding")]
        public IActionResult NewWedding()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("NewWedding");
        }


        [HttpPost("/weddingCreate")]
        public IActionResult WeddingCreate(Wedding weddingToCreate)
        {
             if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            
            weddingToCreate.UserId = (int)HttpContext.Session.GetInt32("UserId");

            db.Weddings.Add(weddingToCreate);
            db.SaveChanges();
            return Success();
        }


        [HttpPost("/wedding/{id}/delete")]
        public IActionResult Delete(int id)
        {
             if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Wedding selectedWedding = db.Weddings.FirstOrDefault(wedding => wedding.WeddingId == id);
            if (selectedWedding == null)
            {
                return Success();
            }

            db.Weddings.Remove(selectedWedding);
            db.SaveChanges();
            return Success();
        }


        [HttpPost("/wedding/{id}/addGuest")]
        public IActionResult AddGuest(int id)
        {

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Guest Check = db.Guests
            .FirstOrDefault(g => g.WeddingId == id && g.UserId == (int)HttpContext.Session.GetInt32("UserId"));
            if(Check == null)
            {

            
            // Guest selectedGuest = db.Guests
            // .FirstOrDefault(g => g.WeddingId == id);
            Guest selectedGuest = new Guest();
            selectedGuest.WeddingId = id;

            selectedGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");
            db.Guests.Add(selectedGuest);
            db.SaveChanges();
            return Success();
            }
            return Success();
        }


        [HttpPost("/wedding/{id}/removeguest")]
        public IActionResult RemoveGuest(int id){

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Guest removingGuest = db.Guests
            .FirstOrDefault(g => g.WeddingId == id && g.UserId == (int)HttpContext.Session.GetInt32("UserId"));
            // removingGuest.WeddingId = id;
            // removingGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");

            db.Guests.Remove(removingGuest);
            db.SaveChanges();
            return Success();




        }



        [HttpGet("/wedding/{id}")]
        public IActionResult WeddingDetails(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SelectedWedding = db.Weddings
            .Include(wed => wed.Guests)
            .ThenInclude(g => g.User)
            .FirstOrDefault(wed => wed.WeddingId == id);

            return View("WeddingDetails");


        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
