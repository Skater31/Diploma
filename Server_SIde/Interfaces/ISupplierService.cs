using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
    }
}
