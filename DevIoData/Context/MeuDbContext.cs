
using DevIoBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Context
{
    public class MeuDbContext : DbContext
    {
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Adicionais> Adicionais { get; set; }

        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carro>()
                .HasOne(c => c.Modelo)
                .WithMany(m => m.Carros)
                .HasForeignKey(c => c.IdModelo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Marca)
                .WithMany(ma => ma.Modelos)
                .HasForeignKey(m => m.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Carro>()
                .HasMany(c => c.Adicionais)
                .WithOne()
                .HasForeignKey(a => a.IdCarro)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}