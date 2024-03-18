using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trial.Models;
using Microsoft.AspNetCore.Http;
namespace Trial.Controllers
{
    public class AuthController : Controller
    {
       
        private readonly TrialContext context;

        public AuthController (TrialContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult SignIn(User1 user)
        {
            var myUser = context.User1s.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if(myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login failed..";
            }
            return View();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("SignIn");
            }
            return View();
        }
          

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}