using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class SupplierController : ControllerBase
    {

        ISupplierService SupplierService;
        public SupplierController(ISupplierService supplierService)
        {
            SupplierService = supplierService;
        }

        // GET: api/<SupplierController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            return SupplierService.GetSupplies();
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public SupplierModel Get(int id)
        {
            return SupplierService.GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public string Post([FromBody] SupplierModel Supplier)
        {
            var result = SupplierService.AddSupplier(Supplier);

            if (result)
            {
                return "Supplier Agregada Correctamente.";
            }
            return "Error al agregar a la entidad.";
        }

        // PUT api/<SupplierController>/5
        [HttpPut]
        public string Put([FromBody] SupplierModel Supplier)
        {
            var result = SupplierService.UpdateSupplier(Supplier);

            if (result)
            {
                return "Supplier Editada Correctamente.";
            }
            return "Error al editar a la entidad.";
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SupplierModel Supplier = new SupplierModel { SupplierId = id };
            var result = SupplierService.DeleteSupplier(Supplier);

            if (result)
            {
                return "Supplier Eliminada Correctamente.";
            }
            return "Error al eliminar a la entidad.";
        }
    }
}
