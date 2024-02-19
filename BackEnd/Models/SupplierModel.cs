namespace BackEnd.Models
{
    public class SupplierModel
    {

        public int SupplierId {  get; set; }
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? City { get; set; }
    }
}
