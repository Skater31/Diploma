using System.ComponentModel.DataAnnotations.Schema;

namespace Server_SIde.Models
{
    public class FreeEquipment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? InventoryNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int MarkId { get; set; }
        public Mark? Mark { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
