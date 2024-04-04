namespace WebAPIIntro.DTO
{
    public class GetAllSuppliersResponseDTO
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string ContactName { get; set; } = "";
        public string ContactTitle { get; set; } = "";
        public string Country { get; set; } = "";
    }
}
