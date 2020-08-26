using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text;
using System;
namespace RandomPasscode.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        
        [HttpGet("")]     
           
        public IActionResult Index()
        {
                int length = 7;
      
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();  
            Random random = new Random();  

            char letter;  

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
            }  
            ViewBag.Password = str_build.ToString();

            int myNum = 0;
            HttpContext.Session.SetInt32("OriginalCount", myNum);
            
            return View("Index");
        }


        [HttpGet("generatedCode")]     
           
        public IActionResult Generate()
        {
            int length = 7;
      
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();  
            Random random = new Random();  

            char letter;  

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);  
            }  
            ViewBag.Password = str_build.ToString();

            int v2 = default;
            
             int? myNum = HttpContext.Session.GetInt32("OriginalCount");
            if(myNum.HasValue)
                v2=myNum.Value;
            HttpContext.Session.SetInt32("OriginalCount", v2+1);

             ViewBag.Number = v2;
             
            
            return View("Generate");
        }

       
    }
}