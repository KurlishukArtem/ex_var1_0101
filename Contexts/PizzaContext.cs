using ex_var1.Models;
using Microsoft.EntityFrameworkCore;

namespace ex_var1.Contexts
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizza { get; set; }
        public PizzaContext()
        {
            Database.EnsureCreated();
            Pizza.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.Config.connect, Config.Config.serverVersion);
        }
    }
}
