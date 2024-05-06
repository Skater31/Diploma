namespace Server_SIde.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Equipment>? Equipment { get; set; }
    }
}
