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
                
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "is taken");
                }
            }

            if (ModelState.IsValid == false)
            {
                
                return View("Index");
            }

            
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("UserName", newUser.FirstName);
            return RedirectToAction("Success", "Home");
        }

        [HttpGet("/home")]
        public IActionResult Success()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AllPicnics = db.Picnics
            .Include(pic => pic.Creator)
            .OrderBy(pic => pic.PicnicDate)
            .Include(pic => pic.Participants)
            .ThenInclude(part => part.User)
            .ToList();
            
            ViewBag.LoggedUser = (int)HttpContext.Session.GetInt32("UserId");

           
            return View("Success");
        }

        


        [HttpPost("/login")]
        public IActionResult Login(LoginUser loginUser)
        {
            

            if (ModelState.IsValid == false)
            {
                
                return View("Index");
            }

            User dbUser = db.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if (dbUser == null)
            {
               
                ModelState.AddModelError("LoginEmail", "Email not found");
                return View("Index");
            }

            
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(loginUser, dbUser.Password, loginUser.LoginPassword);

            if (pwCompareResult == 0)
            {
                
                ModelState.AddModelError("LoginEmail", "wrong password");
                return View("Index");
            }

            
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


        [HttpGet("/new")]
        public IActionResult NewPicnic()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }


            return View("NewPicnic");
        }


        [HttpPost("/picnic/create")]
        public IActionResult CreatePicnic(Picnic newPicnic)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if(ModelState.IsValid == false)
            {
                return View("NewPicnic");
            }

            newPicnic.UserId = (int)HttpContext.Session.GetInt32("UserId");
            
            db.Picnics.Add(newPicnic);
            db.SaveChanges();

            List<Picnic> AllPicnics = db.Picnics
            .Include(pic => pic.Participants)
            .ToList();

            Picnic LastPicnic = AllPicnics.Last();
            

            return RedirectToAction("PicnicDetails", new { id = LastPicnic.PicnicId});

        }

        [HttpGet("/picnic/{id}")]
        public IActionResult PicnicDetails(int id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SelectedPicnic = db.Picnics
            .Include(pic => pic.Participants)
            .ThenInclude(part => part.User)
            .FirstOrDefault(pic => pic.PicnicId == id);

            ViewBag.SelectedUser = db.Picnics
            .Include(pic => pic.Creator)
            .FirstOrDefault(pic => pic.PicnicId == id);

            ViewBag.LoggedUser = (int)HttpContext.Session.GetInt32("UserId");

            return View("PicnicDetails");
        }


        [HttpPost("/picnic/{id}/delete")]
        public IActionResult Delete(int id)
        {
             if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Picnic SelectedPicnic = db.Picnics.FirstOrDefault(pic => pic.PicnicId == id);
            if (SelectedPicnic == null)
            {
                return Success();
            }

            db.Picnics.Remove(SelectedPicnic);
            db.SaveChanges();
            return Success();
        }


        [HttpPost("/picnic/{id}/addParticipant")]
        public IActionResult AddParticipant(int id)
        {

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Participant Check = db.Participants
            .FirstOrDefault(part => part.PicnicId == id && part.UserId == (int)HttpContext.Session.GetInt32("UserId"));
            if(Check == null)
            {

            
            
            Participant selectedParticipant = new Participant();
            selectedParticipant.PicnicId = id;

            selectedParticipant.UserId = (int)HttpContext.Session.GetInt32("UserId");
            db.Participants.Add(selectedParticipant);
            db.SaveChanges();
            return Success();
            }
            return Success();
        }


        [HttpPost("/wedding/{id}/removeparticipant")]
        public IActionResult removeparticipant(int id){

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            Participant removingParticpant = db.Participants
            .FirstOrDefault(part => part.PicnicId == id && part.UserId == (int)HttpContext.Session.GetInt32("UserId"));
           

            db.Participants.Remove(removingParticpant);
            db.SaveChanges();
            return Success();




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
