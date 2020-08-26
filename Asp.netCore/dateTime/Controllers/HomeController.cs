using Microsoft.AspNetCore.Mvc;
namespace DateTime.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        
        [HttpGet("")]     
           
        public ViewResult Index()
        {
            return View();
        }

        
    }
}