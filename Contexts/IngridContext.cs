using ex_var1.Models;
using Microsoft.EntityFrameworkCore;

namespace ex_var1.Contexts
{
    public class IngridContext : DbContext
    {
        public DbSet<Ingrid> Ingrid { get; set; }
        public IngridContext()
        {
            Database.EnsureCreated();
            Ingrid.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.Config.connect, Config.Config.serverVersion);
        }
    }
}
