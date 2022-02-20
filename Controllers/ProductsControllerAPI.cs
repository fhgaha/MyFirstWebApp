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
        public ActionResult<IEnumerable<ProductModelDTO>> Index()
        {
            return products.GetAllProducts().Select(p => new ProductModelDTO(p)).ToList();
        }

        [HttpGet("SearchProducts/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModelDTO>> SearchProducts(string searchTerm)
        {
            return products.SearchProducts(searchTerm).Select(p => new ProductModelDTO(p)).ToList();
        }

        [HttpGet("showoneproduct/{Id}")]
        public ActionResult<ProductModelDTO> ShowOneProduct(int id)
        {
            ProductModel p = products.GetProductById(id);
            ProductModelDTO pDTO = new ProductModelDTO(p);
            return pDTO;
        }

        [HttpPost("InsertOne")]
        //post action
        //expecting a product in json format in the body of the request
        public ActionResult<int> InsertOne(ProductModelDTO p)
        {
            ProductModel product = new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            };
            int newId = products.Insert(product);
            return newId;
        }

        [HttpPut("ProcessEdit")]
        //put request
        //expect json formatted object in the body of the request. id number must match the item being modified
        public ActionResult<ProductModelDTO> ProcessEdit(ProductModelDTO p)
        {
            ProductModel product = new ProductModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            };
            products.Update(product);
            ProductModel modifiedProduct = products.GetProductById(product.Id);
            return new ProductModelDTO(modifiedProduct);
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
