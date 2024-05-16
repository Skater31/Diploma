using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IFreeEquipmentService
    {
        IEnumerable<FreeEquipment> GetAllFreeEquipment(int warehouseId);

        IEnumerable<FreeEquipment> GetAllFreeEquipment();

        FreeEquipment GetById(int id);

        IEnumerable<FreeEquipment> GetAllByEmployeeId(int employeeId);

        void Add(FreeEquipment freeEquipment);

        void Edit(FreeEquipment freeEquipment);

        void Edit(IEnumerable<FreeEquipment> freeEquipment);

        void Delete(FreeEquipment freeEquipment);

        IEnumerable<FreeEquipment> Find(string value, int warehouseId);
    }
}
