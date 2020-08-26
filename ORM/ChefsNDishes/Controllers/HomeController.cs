using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
         private ChefsNDishesContext db;
        public HomeController(ChefsNDishesContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = db.Chefs
            .Include(chef => chef.Dishes)
            .ToList();
            return View("Index", AllChefs);
        }

        [HttpGet("/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/addchef")]
        public IActionResult AddChef(Chef newChef)
        {
            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                return View("New");
            }

            db.Chefs.Add(newChef);
            db.SaveChanges();
            return RedirectToAction("Index");



        }



        [HttpGet("/dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = db.Dishes
            .Include(dish => dish.ChefOwner)
            .ToList();
            return View("Dishes", AllDishes);
        }



        [HttpGet("/dishes/new")]
        public IActionResult NewDishes()
        {
            ViewBag.AllChefs = db.Chefs.ToList();
            return View("NewDishes");
        }

        [HttpPost("/AddDish")]
        public IActionResult AddDish(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                return View("NewDishes");
            }

            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Dishes");



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
