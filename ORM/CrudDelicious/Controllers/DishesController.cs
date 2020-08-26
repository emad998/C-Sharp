using System;
using System.Collections.Generic;
using System.Linq;
using CrudDelicious.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudDelicious.Controllers
{
    public class DishesController : Controller
    {
        private CrudDeliciousContext db;
        public DishesController(CrudDeliciousContext context)
        {
            db = context;
        }

        [HttpGet("/Dishes")]
        public IActionResult All()
        {
            List<Dish> allDishes = db.Dishes.ToList();
            return View("All", allDishes);
        }

        [HttpGet("/dishes/new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("/dishes/create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid == false)
            {
                return View("New");
            }
            db.Dishes.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/dishes/{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (selectedDish == null)
            {
                return RedirectToAction("All");
            }
            
            
            return View("Details", selectedDish);
        }

        [HttpPost("/dishes/{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (selectedDish == null)
            {
                return RedirectToAction("Details", new { dishId = dishId});
            }
            db.Dishes.Remove(selectedDish);
            db.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpGet("/dishes/{dishId}/edit")]
        public IActionResult Edit(int dishId)
        {
             Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (selectedDish == null)
            {
                return RedirectToAction("All");
            }
            return View("Edit", selectedDish);

        }


        [HttpPost("/dishes/{dishId}/update")]
        public IActionResult Update(Dish editedDish, int dishId)
        {
            if (ModelState.IsValid == false)
            {
                return View("Edit", editedDish);
            }

            Dish selectedDish = db.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if (selectedDish == null)
            {
                return RedirectToAction("All");
            }
            
            selectedDish.Name = editedDish.Name;
            selectedDish.Chef = editedDish.Chef;
            selectedDish.Calories = editedDish.Calories;
            selectedDish.Tastiness = editedDish.Tastiness;
            selectedDish.Description = editedDish.Description;

            selectedDish.UpdatedAt = DateTime.Now;

            db.Dishes.Update(selectedDish);
            db.SaveChanges();

            return RedirectToAction("Details", new { dishId = dishId});

        }
    }





}