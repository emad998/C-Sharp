using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductCategoriesTwo.Models;

namespace ProductCategoriesTwo.Controllers
{
    public class HomeController : Controller
    {
        private ProductCategoriesTwoContext db;
        public HomeController(ProductCategoriesTwoContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            
            return View();
        }
        

        [HttpGet("/products")]
        public IActionResult ProductsPage()
        {
            AddProductWrapper WMod = new AddProductWrapper();
            WMod.AllProducts = db.Products
            .Include(product => product.Associations)
            .ToList();
            return View("ProductsPage", WMod);
        }

        [HttpPost("/products/create")]
        public IActionResult ProductsCreate(AddProductWrapper form)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(form.ProdForm);
                db.SaveChanges();
                return RedirectToAction("ProductsPage");
                
            }

            
            return ProductsPage();
        }



        [HttpGet("/categories")]
        public IActionResult CategoriesPage()
        {
            AddCategoryWrapper WMod = new AddCategoryWrapper();
            WMod.AllCategories = db.Categories
            .Include(category => category.Associations)
            .ToList();
            return View("CategoriesPage", WMod);
        }


        [HttpPost("/categories/create")]
        public IActionResult CategoriesCreate(AddCategoryWrapper categoryForm)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Add(categoryForm.CatForm);
                db.SaveChanges();
                return RedirectToAction("CategoriesPage", "Home");
                
            }

            return CategoriesPage();
        }

        [HttpGet("/products/{id}")]
        public IActionResult AddCategoryToProduct(int id)
        {
            AddCategoryToProductWrapper WMod = new AddCategoryToProductWrapper();
            WMod.ToDisplay = db.Products
            .Include(prod => prod.Associations)
            .ThenInclude(assoc => assoc.Category)
            .FirstOrDefault(prod => prod.ProductId == id);

            WMod.CatDropdown = db.Categories
            .Include(category => category.Associations)
            .Where(category => !category.Associations.Any(assoc => assoc.ProductId == WMod.ToDisplay.ProductId))
            .ToList();

            WMod.AllProducts = db.Products
            .Include(p => p.Associations)
            .ThenInclude(assoc => assoc.Category)
            .ToList();

            

            return View("AddCategoryToProduct", WMod);
        }

        [HttpPost("/categoryToProduct/{id}")]
        public IActionResult AddingCategoryToProduct(int id, AddCategoryToProductWrapper catToProdForm)
        {
            if(catToProdForm.AssociationForm == null)
            {
                return RedirectToAction("AddCategoryToProduct", new {id = id});
            }
            catToProdForm.AssociationForm.ProductId = id;
            db.Associations.Add(catToProdForm.AssociationForm);
            db.SaveChanges();
            return RedirectToAction("AddCategoryToProduct", new {id = id});

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
