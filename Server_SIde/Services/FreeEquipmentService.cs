using Microsoft.EntityFrameworkCore;
using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class FreeEquipmentService : IFreeEquipmentService
    {
        private readonly ApplicationContext _applicationContext;

        public FreeEquipmentService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<FreeEquipment> GetAllFreeEquipment(int warehouseId)
        {
            var freeEquipments = _applicationContext.FreeEquipments.
                Include("Mark").Include("Supplier").
                Where(fe => fe.WarehouseId == warehouseId).ToList();

            return freeEquipments;
        }

        public IEnumerable<FreeEquipment> GetAllFreeEquipment()
        {
            var freeEquipments = _applicationContext.FreeEquipments.
                Include("Mark").Include("Supplier").
                ToList();

            return freeEquipments;
        }

        public FreeEquipment GetById(int id)
        {
            var freeEquipment = _applicationContext.FreeEquipments.
                Include("Mark").Include("Supplier").
                FirstOrDefault(fe => fe.Id == id);

            return freeEquipment;
        }

        public IEnumerable<FreeEquipment> GetAllByEmployeeId(int employeeId)
        {
            var emploeesFreeEquipment = _applicationContext.FreeEquipments.
                Include("Mark").Include("Supplier").
                Where(fe => fe.EmployeeId ==  employeeId).ToList();

            return emploeesFreeEquipment;
        }

        public void Add(FreeEquipment freeEquipment)
        {
            _applicationContext.FreeEquipments.Add(freeEquipment);
            _applicationContext.SaveChanges();
        }

        public void Edit(FreeEquipment freeEquipment)
        {
            _applicationContext.FreeEquipments.Update(freeEquipment);
            _applicationContext.SaveChanges();
        }

        public void Delete(FreeEquipment freeEquipment)
        {
            _applicationContext.FreeEquipments.Remove(freeEquipment);
            _applicationContext.SaveChanges();
        }

        public IEnumerable<FreeEquipment> Find(string value, int warehouseId)
        {
            var foundFreeEquipment = new List<FreeEquipment>();

            value = value.Trim().ToLower();

            var freeEquipment = _applicationContext.FreeEquipments.
                Include("Mark").Include("Supplier").
                Where(fe => fe.WarehouseId == warehouseId).AsQueryable();

            foreach (var freeEquip in freeEquipment)
            {
                if (freeEquip.Id.ToString().Contains(value) ||
                    freeEquip.Name.ToLower().Contains(value) ||
                    freeEquip.InventoryNumber.ToString().Contains(value) ||
                    freeEquip.Price.ToString().Contains(value) ||
                    freeEquip.MarkId.ToString().Contains(value) ||
                    freeEquip.Mark.MarkName.ToLower().Contains(value) ||
                    freeEquip.Supplier.SupplierName.ToLower().Contains(value) ||
                    freeEquip.Supplier.ContactNumber.ToLower().Contains(value))
                {
                    foundFreeEquipment.Add(freeEquip);
                }
            }

            return foundFreeEquipment;
        }
    }
}
