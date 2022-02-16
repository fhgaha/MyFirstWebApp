using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            var carModel = new HardCodedCarDataRepository();
            return View(carModel.GetAllProducts());
        }
    }
}
