using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        { 
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        SupplierModel Convertir(Supplier Supplier) 
        {
            return new SupplierModel
            {
                SupplierId = Supplier.SupplierId,
                CompanyName = Supplier.CompanyName,
                ContactName = Supplier.ContactName,
                City = Supplier.City
            };
        }

        Supplier Convertir(SupplierModel Supplier)
        {
            return new Supplier
            {
                SupplierId = Supplier.SupplierId,
                CompanyName = Supplier.CompanyName,
                ContactName = Supplier.ContactName,
                City = Supplier.City
            };
        }

        public bool AddSupplier(SupplierModel Supplier)
        {
            Supplier entity = Convertir(Supplier);
            _unidadDeTrabajo._SupplierDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        public bool DeleteSupplier(SupplierModel Supplier)
        {
            Supplier entity = Convertir(Supplier);
            _unidadDeTrabajo._SupplierDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public SupplierModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._SupplierDAL.Get(id);

            SupplierModel SupplierModel = Convertir(entity);
            return SupplierModel;
        }

        public IEnumerable<SupplierModel> GetSupplies()
        {
            var result = _unidadDeTrabajo._SupplierDAL.GetAll();
            List<SupplierModel> lista = new List<SupplierModel>();
            foreach (var Supplier in result)
            {
                lista.Add(Convertir(Supplier));
                    
            }
            return lista;
        }

        public bool UpdateSupplier(SupplierModel Supplier)
        {
            Supplier entity = Convertir(Supplier);
            _unidadDeTrabajo._SupplierDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}
