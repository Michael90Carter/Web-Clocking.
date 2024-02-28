using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trial.Models;

namespace Trial.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        [HttpGet("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet("signin")]
        public IActionResult SignIn(string returnUrl = null)
        {
            
            {
                if (returnUrl != null)
                    return RedirectToAction(returnUrl);
                
                        return Redirect("/");
            }

            return View();
        }
        [HttpGet("signout")]
        [Authorize]
      /*  public async Task<IActionResult> Signout()
        {
            if (SessionManager.IsAuthenticated)
            {
                await SessionManager.SignoutAsync();
                return Redirect("Account/signin");
            }

            return View(new SignUpModel());
        }*/



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}