using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {

        // GET api/<controller>/Asparagus
        [HttpGet("{category}")]
        public string Get(string category)
        {
            List<Product> Products = SQLQueries.GetProductListings(category);

            //Convert to JSON
            string products = JsonConvert.SerializeObject(Products);

            return products;
        }
    }
}
