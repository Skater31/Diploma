using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationContext _applicationContext;

        public SupplierService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            var suppliers = _applicationContext.Suppliers.ToList();

            return suppliers;
        }
    }
}
