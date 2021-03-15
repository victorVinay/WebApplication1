using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using System.Web;
using System.Text.RegularExpressions;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        
        private readonly IGame _key;
        
        

        public GameController(IGame key)
        {
            _key = key;
        }
        private static int i;

        public IActionResult Index(string guess)
        {
            String AllowedChars = @"[0-9]";

            if (guess != null && (Regex.IsMatch(guess, AllowedChars)))
            {


                string str  = "You Won";

                var res = _key.Compare(guess);
                i++;

                if (res.Equals(str))
                {
                    ViewBag.message = $"{i.ToString()}";
                    return View("Winner");
                }
                
                ViewBag.message = $"Attempt - {i.ToString()}                Output -  {res}";
                
                return View();
            }
            else
            {

                return View();
            }

                
        }

        /*private IActionResult View(string v, object models)
        {
            throw new NotImplementedException();
        }*/
    }
}
