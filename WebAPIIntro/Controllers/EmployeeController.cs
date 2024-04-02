using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            NorthwindContext db = new NorthwindContext();
            List<Employee> employees = db.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            NorthwindContext db = new NorthwindContext();
            Employee employee = db.Employees.FirstOrDefault(q => q.EmployeeId == id);

            if(employee == null)
            {
                return NotFound("Employee not found!");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            NorthwindContext db = new NorthwindContext();
            db.Employees.Add(employee);
            db.SaveChanges();

            return Ok("Ekleme islemi basarili");
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            NorthwindContext db = new NorthwindContext();
            Employee employee = db.Employees.Find(id);



            if(employee == null)
            {
                return NotFound("Boyle bir employee bulunamadi");
            }

            db.Employees.Remove(employee);
            db.SaveChanges();
            return Ok("Islem basarili!");
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            NorthwindContext db = new NorthwindContext();

            //oncelikle guncellenecek datayi buluyorum
            Employee entity = db.Employees.FirstOrDefault(q => q.EmployeeId == employee.EmployeeId);

            entity.FirstName = employee.FirstName;
            entity.LastName = employee.LastName;
            entity.Title = employee.Title;
            db.SaveChanges();

            return Ok("Guncelleme islemi basarili!");

        }





        //[HttpPut("{id}")]
        //public IActionResult Put(Employee employee, int id)
        //{
        //    NorthwindContext db = new NorthwindContext();

        //    //oncelikle guncellenecek datayi buluyorum
        //    Employee entity = db.Employees.FirstOrDefault(q => q.EmployeeId == id);

        //    entity.FirstName = employee.FirstName;
        //    entity.LastName = employee.LastName;
        //    entity.Title = employee.Title;
        //    db.SaveChanges();

        //    return Ok("Guncelleme islemi basarili!");

        //}

    }
}
