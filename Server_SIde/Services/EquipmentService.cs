using Microsoft.EntityFrameworkCore;
using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ApplicationContext _applicationContext;

        public EquipmentService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Equipment> GetAllEquipment(int workshopId)
        {
            var equipments = _applicationContext.Equipments.Include("Mark").Where(e => e.WorkshopId == workshopId).ToList();

            return equipments;
        }

        public Equipment GetById(int id)
        {
            var equipment = _applicationContext.Equipments.Include("Mark").FirstOrDefault(e => e.Id == id);

            return equipment;
        }

        public void Add(Equipment equipment)
        {
            _applicationContext.Equipments.Add(equipment);
            _applicationContext.SaveChanges();
        }

        public void Edit(Equipment equipment)
        {
            _applicationContext.Equipments.Update(equipment);
            _applicationContext.SaveChanges();
        }

        public void Delete(Equipment equipment)
        {
            _applicationContext.Equipments.Remove(equipment);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<Equipment> Find(string value, int workshopId)
        {
            var foundEquipment = new List<Equipment>();

            value = value.Trim().ToLower();

            var equipment = _applicationContext.Equipments.Include("Mark").Where(e => e.WorkshopId == workshopId).AsQueryable();

            foreach (var equip in equipment)
            {
                if (equip.Id.ToString().Contains(value) ||
                    equip.Name.ToLower().Contains(value) ||
                    equip.InventoryNumber.ToString().Contains(value) ||
                    equip.Price.ToString().Contains(value) ||
                    equip.YearOfInstalation.ToString().Contains(value) ||
                    equip.MarkId.ToString().Contains(value) ||
                    equip.Mark.MarkName.ToLower().Contains(value))
                {
                    foundEquipment.Add(equip);
                }
            }

            return foundEquipment;
        }
    }
}
