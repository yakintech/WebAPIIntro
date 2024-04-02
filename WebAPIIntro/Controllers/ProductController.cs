using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.DTO;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwindContext db = new NorthwindContext();
            //List<Product> products = db.Products.ToList();

            //var data = db.Products.Select(q => new
            //{
            //    q.ProductName,
            //    q.UnitPrice
            //}).ToList();



            List<GetAllProductsResponseDTO> model = db.Products.Select(q => new GetAllProductsResponseDTO
            {
                Id = q.ProductId,
                ProductName = q.ProductName.ToUpper(),
                UnitPrice = q.UnitPrice,
                UnitsInStock = q.UnitsInStock
            }).ToList();

            

            return Ok(model);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NorthwindContext db = new NorthwindContext();

            Product product = db.Products.Find(id);

            if(product != null)
            {
                GetProductByIdResponseDto model = new GetProductByIdResponseDto();
                model.Id = product.ProductId;
                model.ProductName = product.ProductName;
                model.UnitPrice = product.UnitPrice;
                model.UnitsInStock = product.UnitsInStock;
                model.QuantityPerUnit = product.QuantityPerUnit;
                model.KDVPrice = product.UnitPrice * 1.18m;

                return Ok(model);

            }

            return NotFound();

          
        }

        [HttpPost]
        public IActionResult Create(CreateProductRequestDto model)
        {
            NorthwindContext db = new NorthwindContext();
            Product product = new Product();
            product.ProductName = model.ProductName;
            product.UnitPrice = model.UnitPrice;

            db.Products.Add(product);
            db.SaveChanges();

            return Ok(model);
        }

    }
}
