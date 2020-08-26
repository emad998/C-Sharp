using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        
        [HttpGet("")]     
           
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Method(string nameLabel, string locationLabel, string languageLabel, string commentLabel)
        {
        // Do something with form input
            ViewBag.name = nameLabel;
            ViewBag.location = locationLabel;
            ViewBag.language = languageLabel;
            ViewBag.comment = commentLabel;
            return View();
        }
    }
}