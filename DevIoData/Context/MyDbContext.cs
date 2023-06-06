using DevIoBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Adicionais> Adicionais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

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

            modelBuilder.Entity<CarroAdicionais>()
                .HasKey(cc => new { cc.IdCarro, cc.IdAdicionais });

            modelBuilder.Entity<CarroAdicionais>()
                .HasOne(cc => cc.Carro)
                .WithMany(c => c.Adicionais)
                .HasForeignKey(cc => cc.IdCarro);

            modelBuilder.Entity<CarroAdicionais>()
                .HasOne(cc => cc.Adicionais)
                .WithMany()
                .HasForeignKey(cc => cc.IdAdicionais);

            modelBuilder.Entity<Endereco>()
               .HasKey(e => e.IdEndereco);

            modelBuilder.Entity<Telefone>()
                .HasKey(t => t.IdTelefone);

            modelBuilder.Entity<Cliente>()
               .HasOne(c => c.Endereco)
               .WithMany()
               .HasForeignKey(c => c.IdEndereco)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Telefone)
                .WithMany()
                .HasForeignKey(c => c.IdTelefone)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Funcionario>()
               .HasOne(f => f.Endereco)
               .WithMany()
               .HasForeignKey(f => f.IdEndereco)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Funcionario>()
                .HasOne(f => f.Telefone)
                .WithMany()
                .HasForeignKey(f => f.IdTelefone)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}



