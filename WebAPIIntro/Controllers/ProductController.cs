using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<Product> GetAll()
        {
            NorthwindContext db = new NorthwindContext();
            List<Product> products = db.Products.ToList();
            return products;
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            NorthwindContext db = new NorthwindContext();
            Product product = db.Products.FirstOrDefault(x => x.ProductId == id);
            return product;
        }
    }
}
