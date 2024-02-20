using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace FrontEnd.Helpers.Implementations
{
    public class SupplierHelper : ISupplierHelper
    {
        IServiceRepository ServiceRepository;

        public SupplierHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public SupplierViewModel AddSupplier(SupplierViewModel Supplier)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Supplier", Convertir(Supplier));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  SupplierAPI = JsonConvert.DeserializeObject<Supplier>(content);
            }

            return Supplier;
        }


        Supplier Convertir(SupplierViewModel Supplier)
        {
            return new Supplier
            {
                SupplierId = Supplier.SupplierId,
                CompanyName = Supplier.CompanyName,
                ContactName = Supplier.ContactName,
                City = Supplier.City
            };
        }

        SupplierViewModel Convertir(Supplier Supplier)
        {
            return new SupplierViewModel
            {
                SupplierId = Supplier.SupplierId,
                CompanyName = Supplier.CompanyName,
                ContactName = Supplier.ContactName,
                City = Supplier.City
            };
        }


        public SupplierViewModel DeleteSupplier(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Supplier/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new SupplierViewModel();
        }

        public List<SupplierViewModel> GetSupplies()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Supplier");
            List<Supplier> resultado = new List<Supplier>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Supplier>>(content);
            }
            List<SupplierViewModel> lista = new List<SupplierViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }
            return lista;



        }

        public SupplierViewModel GetSupplier(int id)
        {
            SupplierViewModel Supplier = new SupplierViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Supplier/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                Supplier = Convertir(JsonConvert.DeserializeObject<Supplier>(content));
            }

            return Supplier;
        }

        public SupplierViewModel UpdateSupplier(SupplierViewModel Supplier)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Supplier", Convertir(Supplier));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  SupplierAPI = JsonConvert.DeserializeObject<Supplier>(content);
            }

            return Supplier;
        }
    }
}
