using Microsoft.EntityFrameworkCore;
using Server_SIde.Models;

namespace Server_SIde.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
    }
}
