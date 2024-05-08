using System.ComponentModel.DataAnnotations.Schema;

namespace Server_SIde.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }

        public int PositionId { get; set; }
        public Position? Position { get; set; }

        public List<FreeEquipment>? FreeEquipment { get; set; } = new();
    }
}
