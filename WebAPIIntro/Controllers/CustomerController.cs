using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwindContext db = new NorthwindContext();
            List<Customer> customers = db.Customers.ToList();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            NorthwindContext db = new NorthwindContext();

            Customer customer = db.Customers.FirstOrDefault(q => q.CustomerId == id);

            if(customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            NorthwindContext context = new NorthwindContext();
            context.Customers.Add(customer);
            context.SaveChanges();
            return Ok(context);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            NorthwindContext context = new NorthwindContext();
            Customer customer = context.Customers.FirstOrDefault(q => q.CustomerId == id);
            if(customer == null)
            {
                return NotFound();
            }

            context.Customers.Remove(customer);
            context.SaveChanges();
            return Ok("Silme islemi basarili");
        }


        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            NorthwindContext db = new NorthwindContext();

            Customer entity = db.Customers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

            if(entity == null)
            {
                return NotFound();
            }

            entity.CompanyName = customer.CompanyName;
            entity.ContactName = customer.ContactName;
            entity.Phone = customer.Phone;

            db.SaveChanges();
            return Ok(entity);
        }

    }
}
