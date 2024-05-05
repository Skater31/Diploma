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

        public IEnumerable<Equipment> GetAllEquipment()
        {
            var equipments = _applicationContext.Equipments.Include("Mark").ToList();

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
    }
}
