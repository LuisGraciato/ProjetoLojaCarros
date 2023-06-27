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
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaFormaPagamento> VendaFormasPagamento { get; set; }
        public DbSet<VendaCarro> VendaCarros { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<CarroAdicionais> CarroAdicionais { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Adicionais>()
               .HasKey(t => t.IdAdicionais);

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
                 .HasKey(t => t.IdCarroAdicionais);

            modelBuilder.Entity<Carro>()
                .HasMany(v => v.CarroAdicionais)
                .WithOne(vp => vp.Carro)
                .HasForeignKey(vp => vp.IdCarro)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarroAdicionais>()
                .HasOne(vp => vp.Adicionais)
                .WithMany(fp => fp.CarroAdicionais)
                .HasForeignKey(vp => vp.IdAdicionais)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Venda>()
                .HasKey(t => t.IdVenda);

            modelBuilder.Entity<VendaCarro>()
                .HasKey(t => t.IdVendaCarro);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasKey(t => t.IdVendaFormaPagamento);

            modelBuilder.Entity<FormaPagamento>()
                .HasKey(t => t.IdFormaPagamento);

            modelBuilder.Entity<Venda>()
                .HasMany(v => v.VendaFormasPagamento)
                .WithOne(vp => vp.Venda)
                .HasForeignKey(vp => vp.IdVenda)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
                .HasMany(vc => vc.CarrosVendidos)
                .WithOne(v => v.Venda)
                .HasForeignKey(vc => vc.IdVenda)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VendaFormaPagamento>()
                .HasOne(vp => vp.FormaPagamento)
                .WithMany(fp => fp.VendaFormasPagamento)
                .HasForeignKey(vp => vp.IdFormaPagamento)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendaCarro>()
                .HasOne(vc => vc.Carro)
                .WithMany(c => c.VendaCarros)
                .HasForeignKey(vc => vc.IdCarro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NotaFiscal>()
                .HasKey(nf => nf.IdNotaFiscal);

            modelBuilder.Entity<NotaFiscal>()
                .HasOne(nf => nf.Venda)
                .WithMany(v => v.NotasFiscais)
                .HasForeignKey(nf => nf.IdVenda)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }

}



