using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Discover.Controllers
{
    public class HomeController : Controller
    {
        //Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult HiThere()
        {
            // Views/Home/Index.cshtml
            // Views/Shared/Index.cshtml
            return View("Index");
        }


        // localhost:5000/hello
        [HttpGet("hello")]
        public string Hello()
        {
            return "Hi Again!";
        }

        // localhost:5000/users/???
        [HttpGet("users/{username}/{location}")]
        public string HelloUser(string username, string location)
        {
            if(location == "Chicago")
               return $"Hello {username} from {location}. go Bears!!";
            return $"Hello {username} from {location}";
        }
    }
}
