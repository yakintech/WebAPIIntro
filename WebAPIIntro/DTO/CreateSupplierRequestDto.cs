using System.ComponentModel.DataAnnotations;

namespace WebAPIIntro.DTO
{
    public class CreateSupplierRequestDto
    {
        [Required(ErrorMessage = "CompanyName is required")]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
    }
}
