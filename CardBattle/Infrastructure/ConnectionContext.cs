using CardBattle.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CardBattle.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Players> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432; Database=card_battle;" +
              "User Id=postgres;" +
              "Password=123;");
    }
}
