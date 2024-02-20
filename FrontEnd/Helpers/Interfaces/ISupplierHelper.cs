using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface ISupplierHelper
    {
        List<SupplierViewModel> GetSupplies();
        SupplierViewModel GetSupplier(int id);
        SupplierViewModel AddSupplier(SupplierViewModel supplier);
        SupplierViewModel DeleteSupplier(int id);
        SupplierViewModel UpdateSupplier(SupplierViewModel supplier);
    }
}
