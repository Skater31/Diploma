using Microsoft.EntityFrameworkCore;
using Server_SIde.Models;

namespace Server_SIde.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<FreeEquipment> FreeEquipments { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
    }
}
