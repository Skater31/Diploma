using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;
using Server_SIde.Services;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return _supplierService.GetAllSuppliers();
        }

        [HttpPost]
        [Route("add")]
        public void Add(Supplier supplier)
        {
            _supplierService.Add(supplier);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Supplier supplier)
        {
            _supplierService.Delete(supplier);
        }
    }
}
