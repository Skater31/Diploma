using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();

        void Add(Supplier supplier);

        void Delete(Supplier supplier);
    }
}
