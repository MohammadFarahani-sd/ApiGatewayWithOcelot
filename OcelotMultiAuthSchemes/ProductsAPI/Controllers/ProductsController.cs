using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using System.Collections.Generic;
using ProductsAPI.Authentication.Authorization;
using ProductsAPI.Authentication.Filters;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
            
        }
        [HttpGet]
        [TypeFilter(typeof(AuthorizeAttribute), Arguments = new object[] { new[] { Role.Admin } })]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            int size = 10;
            var products = new List<Product>(size);

            for (int index = 1; index <= size; index++)
            {
                products.Add(new()
                {
                    Id = index,
                    Description = $"Product {index}",
                    CategoryId = index
                });
            }

            return products;
        }
    }
}
