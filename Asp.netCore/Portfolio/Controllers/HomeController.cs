using Microsoft.AspNetCore.Mvc;
namespace Portfolio.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        
        [HttpGet("")]     
           
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("projects")]     
           
        public ViewResult Projects()
        {
            return View();
        }

        [HttpGet("contact")]     
           
        public ViewResult Contacts()
        {
            return View();
        }
    }
}