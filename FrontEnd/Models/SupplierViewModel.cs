namespace FrontEnd.Models
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? City { get; set; }
    }
}
