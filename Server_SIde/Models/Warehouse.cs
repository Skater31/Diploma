namespace Server_SIde.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<FreeEquipment>? FreeEquipment { get; set; }
    }
}
