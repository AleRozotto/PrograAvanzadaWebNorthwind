using BackEnd.Models;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierModel> GetSupplies();
        SupplierModel GetById(int id);
        bool AddSupplier(SupplierModel Supplier);
        bool UpdateSupplier(SupplierModel Supplier);
        bool DeleteSupplier(SupplierModel Supplier);
    }
}