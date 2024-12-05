using Microsoft.EntityFrameworkCore;
using System.Reflection;
using uol_backend.DOMAIN.Entities;

namespace uol_backend.API.Infraestrutura.BancoDeDados
{
    public class BancoDataContext : DbContext
    {
        public BancoDataContext(DbContextOptions<BancoDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Jogador> Jogadores { get; set; }
    }
}
