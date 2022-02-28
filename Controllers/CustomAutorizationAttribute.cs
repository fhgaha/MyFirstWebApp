using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication1.Controllers
{
    internal class CustomAutorizationAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string userName = context.HttpContext.Session.GetString("username");

            if (userName == null)
                context.Result = new RedirectResult("/login");  //login is the view 'Login/Index.cshtml'
        }
    }
}