using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "single product";
        }

        [HttpGet]
        public List<string> GetProducts()
        {
            return new List<string>();
        }
    }
}