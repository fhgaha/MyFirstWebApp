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
    [ApiController]
    [Route("api/")]
    public class ProductsControllerAPI : ControllerBase
    {
        ProductsDAO products;

        public ProductsControllerAPI()
        {
            products = new ProductsDAO();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        {
            return products.GetAllProducts();
        }
        
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            return products.SearchProducts(searchTerm);
        }
        
        [HttpGet("showoneproduct/{Id}")]
        public ActionResult<ProductModel> ShowOneProduct(int id)
        {
            return products.GetProductById(id);
        }

        [HttpPost("InsertOne")]
        //post action
        //expecting a product in json format in the body of the request
        public ActionResult<int> InsertOne(ProductModel product)
        {
            int newId = products.Insert(product);
            return newId;
        }

        [HttpPut("ProcessEdit")]
        //put request
        //expect json formatted object in the body of the request. id number must match the item being modified
        public ActionResult<ProductModel> ProcessEdit(ProductModel product)
        {
            products.Update(product);
            return products.GetProductById(product.Id);
        }
        
        [HttpDelete("DeleteOne/{id}")]
        public ActionResult<bool> DeleteOne(int id)
        {
            ProductModel product = products.GetProductById(id);
            int success = products.Delete(product);
            return success == -1 ? false : true;
        }
    }
}
