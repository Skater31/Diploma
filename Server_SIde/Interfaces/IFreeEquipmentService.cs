using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IFreeEquipmentService
    {
        IEnumerable<FreeEquipment> GetAllFreeEquipment(int warehouseId);

        FreeEquipment GetById(int id);

        void Add(FreeEquipment freeEquipment);

        void Edit(FreeEquipment freeEquipment);

        void Delete(FreeEquipment freeEquipment);

        IEnumerable<FreeEquipment> Find(string value, int warehouseId);
    }
}
