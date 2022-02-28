using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet][CustomAutorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("Private section");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            var securityService = new SecurityService();

            if (securityService.IsValid(user))
            {
                HttpContext.Session.SetString("username", user.UserName);

                return View("LoginSuccess", user);
            }
            else
            {
                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
    }
}
