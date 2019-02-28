using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class GenericProductsController : Controller
    {
        // GET api/GenericProducts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> genericProductNames = SQLQueries.GetGenericProductNames();
            //string genericProducts = new JavaScriptSerializer().Serialize(genericProductNames);

            return genericProductNames;
        }
    }
}
