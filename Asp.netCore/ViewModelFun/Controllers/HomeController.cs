using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;
using System.Collections.Generic;
namespace ViewModelFun.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        
        [HttpGet("")]     
           
        public IActionResult Index()
        {
            string Message = "Hello emad hello emad hello emad hello emad hello emad";
            return View("Index", Message);
        }

        [HttpGet("numbers")]     
           
        public IActionResult Numbers()
        {
            int[] numbers = new int[]
            {
                1,2,3,43,5
            };
            return View("Numbers", numbers);
        }

        [HttpGet("user")]     
           
        public IActionResult SingleUser()
        {
            User FirstPerson = new User()
            {
                FirstName = "Emad",
                LastName = "Hanna"
            };
            return View("SingleUser", FirstPerson);
        }

        [HttpGet("users")]  
        public IActionResult Users()
        {
            User FirstPerson = new User()
            {
                FirstName = "Emad",
                LastName = "Hanna"
            };
            User SecondPerson = new User()
            {
                FirstName = "Donald",
                LastName = "Leblanc"
            };
            List<User> Persons = new List<User>()
            {
                FirstPerson, SecondPerson
            };
            return View("Users", Persons);
        }
    }
}