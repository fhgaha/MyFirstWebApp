using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApplication1.Models;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    internal class LogActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Controller loginController = (Controller)context.Controller;
            UserModel user = (UserModel)loginController.ViewData.Model; 

            MyLogger.GetInstance().Info("Leaving the ProcessLogin method");
            MyLogger.GetInstance().Info("User that logged in: " + user.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin method");
        }
    }
}