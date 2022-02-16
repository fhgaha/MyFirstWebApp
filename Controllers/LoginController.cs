using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel)
        {
            var securityService = new SecurityService();

            if (securityService.IsValid(userModel))
                return View("LoginSuccess", userModel);
            return View("LoginFailure", userModel);
        }
    }
}
