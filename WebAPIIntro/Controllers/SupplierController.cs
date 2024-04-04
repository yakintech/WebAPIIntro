using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro.DTO;
using WebAPIIntro.Models;

namespace WebAPIIntro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        NorthwindContext db;

        public SupplierController()
        {
            db = new NorthwindContext();
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            List<GetAllSuppliersResponseDTO> model = db.Suppliers.Select(q => new GetAllSuppliersResponseDTO()
            {
                Id = q.SupplierId,
                CompanyName = q.CompanyName,
                ContactName = q.ContactName,
                ContactTitle = q.ContactTitle,
                Country = q.Country
            }).ToList();


            return Ok(model);
        }


        [HttpPost]
        public IActionResult CreateSupplier(CreateSupplierRequestDto model)
        {
            Supplier supplier = new Supplier();
            supplier.CompanyName = model.CompanyName;
            supplier.ContactName = model.ContactName;
            supplier.ContactTitle = model.ContactTitle;

            db.Suppliers.Add(supplier);
            db.SaveChanges();

            return Ok();
        }



    }
}


