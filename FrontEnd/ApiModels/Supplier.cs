namespace FrontEnd.ApiModels
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? City { get; set; }
    }
}
