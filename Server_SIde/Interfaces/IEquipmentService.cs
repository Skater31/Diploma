using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IEquipmentService
    {
        IEnumerable<Equipment> GetAllEquipment(int workshopId);

        Equipment GetById(int id);

        void Add(Equipment equipment);

        void Edit(Equipment equipment);

        void Delete(Equipment equipment);

        IEnumerable<Equipment> Find(string value, int workshopId);
    }
}
