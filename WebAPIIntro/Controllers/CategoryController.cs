using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwindContext db = new NorthwindContext();
            List<Category> categories = db.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NorthwindContext db = new NorthwindContext();
            Category category = db.Categories.FirstOrDefault(x => x.CategoryId == id);

            if(category == null)
            {
                return NotFound("Boyle bir category mevcut degil");
            }
            
            return Ok(category);

        }
    }
}
