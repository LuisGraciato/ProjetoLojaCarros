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
        public DbSet<CarroAdicionais> CarroAdicionais { get; set; }
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

            modelBuilder.Entity<CarroCarroAdicionais>()
                .HasKey(cc => new { cc.IdCarro, cc.IdAdicionais });

            modelBuilder.Entity<CarroCarroAdicionais>()
                .HasOne(cc => cc.Carro)
                .WithMany(c => c.CarroAdicionais)
                .HasForeignKey(cc => cc.IdCarro);

            modelBuilder.Entity<CarroCarroAdicionais>()
                .HasOne(cc => cc.CarroAdicionais)
                .WithMany()
                .HasForeignKey(cc => cc.IdAdicionais);

            modelBuilder.Entity<Endereco>()
               .HasKey(e => e.IdEndereco);

            modelBuilder.Entity<Telefone>()
                .HasKey(t => t.IdTelefone);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Telefones)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.IdCliente);

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
                .HasMany(f => f.Enderecos)
                .WithOne(e => e.Funcionario)
                .HasForeignKey(e => e.IdFuncionario);

            modelBuilder.Entity<Funcionario>()
                .HasMany(f => f.Telefones)
                .WithOne(t => t.Funcionario)
                .HasForeignKey(t => t.IdFuncionario);

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



