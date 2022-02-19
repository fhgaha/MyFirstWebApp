using Bogus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO products;

        public ProductsController()
        {
            products = new ProductsDAO();
        }

        public IActionResult Index()
        {
            return View(products.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult ShowDetails(int id)
        {
            return View(products.GetProductById(id));
        }

        public IActionResult ShowOneProductJSON(int id)
        {
            return Json(products.GetProductById(id));
        }

        public IActionResult Edit(int id)
        {
            ProductModel product = products.GetProductById(id);
            return View("ShowEdit", product);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult ProcessEditReturnPartial (ProductModel product)
        {
            products.Update(product);
            return PartialView("_productCard", product);
        }

        public IActionResult Delete(int id)
        {
            ProductModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductModel product)
        {
            products.Insert(product);
            return View("ShowDetails", product);
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Welcome(string name, int secretNumber = 13)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumber;
            return View();
        }
    }
}
