using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductCategories.Models;

namespace ProductCategories.Controllers
{
    public class HomeController : Controller
    {
        private ProductCategoriesContext db;
        public HomeController(ProductCategoriesContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("/products")]
        public IActionResult AllProducts()
        {
            ViewBag.AllProducts = db.Products.ToList();
            return View("AllProducts");
        }


        [HttpPost("/product/create")]
        public IActionResult ProductCreate(Product newProduct)
        {

            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                return AllProducts();
            }

            db.Products.Add(newProduct);
            db.SaveChanges();
            ViewBag.AllProducts = db.Products.ToList();
            return RedirectToAction("AllProducts");
        }

        [HttpGet("/categories")]
        public IActionResult AllCategories()
        {
            ViewBag.AllCategories = db.Categories.ToList();
            return View("AllCategories");
        }

        [HttpPost("/category/create")]
        public IActionResult CategoryCreate(Category newCategory)
        {
            if (ModelState.IsValid == false)
            {
                // send back to the page with the form so error messages are displayed
                return AllCategories();
            }

            db.Categories.Add(newCategory);
            db.SaveChanges();
            ViewBag.AllCategories = db.Categories.ToList();
            return RedirectToAction("AllCategories");
        }

        [HttpGet("/products/{id}")]
        public IActionResult Product(int id)
        {
            Product SelectedProduct = db.Products
            .Include(product => product.Associations)
            .ThenInclude(association => association.Category)
            .FirstOrDefault(product => product.ProductId == id);

            ViewBag.CategoriesDropDown = db.Categories
            .Include(category => category.Products)
            .ThenInclude(product => product.Product)
            .Where(category => category.Products.FirstOrDefault(prodId => prodId.ProductId == id) == null)
            .ToList();




            return View("Product", SelectedProduct);

        }


        [HttpPost("/products/{productId}/addCategory")]
        public IActionResult AddCategory(int categoryId, int productId, Association newAssociation)
        {
            db.Associations.Add(newAssociation);
            db.SaveChanges();
           return RedirectToAction("AllProducts");
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
