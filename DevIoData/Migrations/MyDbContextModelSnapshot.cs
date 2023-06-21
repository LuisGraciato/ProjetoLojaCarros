﻿// <auto-generated />
using System;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevIoData.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DevIoBusiness.Models.Adicionais", b =>
                {
                    b.Property<int>("IdAdicionais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdicionais"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("IdAdicionais");

                    b.ToTable("Adicionais");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Carro", b =>
                {
                    b.Property<int>("IdCarro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarro"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("EstadoConservacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("int");

                    b.HasKey("IdCarro");

                    b.HasIndex("IdModelo");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.CarroAdicionais", b =>
                {
                    b.Property<int>("IdCarro")
                        .HasColumnType("int");

                    b.Property<int>("IdAdicionais")
                        .HasColumnType("int");

                    b.Property<int?>("AdicionaisIdAdicionais")
                        .HasColumnType("int");

                    b.HasKey("IdCarro", "IdAdicionais");

                    b.HasIndex("AdicionaisIdAdicionais");

                    b.HasIndex("IdAdicionais");

                    b.ToTable("CarroAdicionais");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdTelefone")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdTelefone");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Endereco", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEndereco"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEndereco");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("DevIoBusiness.Models.FormaPagamento", b =>
                {
                    b.Property<int>("IdFormaPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFormaPagamento"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFormaPagamento");

                    b.ToTable("FormasPagamento");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdTelefone")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco");

                    b.HasIndex("IdTelefone");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarca"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMarca");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Modelo", b =>
                {
                    b.Property<int>("IdModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModelo"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroLugares")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPortas")
                        .HasColumnType("int");

                    b.Property<string>("TipoCombustivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoMotor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdModelo");

                    b.HasIndex("IdMarca");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("DevIoBusiness.Models.NotaFiscal", b =>
                {
                    b.Property<int>("IdNotaFiscal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotaFiscal"));

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("NumeroNota")
                        .HasColumnType("int");

                    b.HasKey("IdNotaFiscal");

                    b.HasIndex("IdVenda");

                    b.ToTable("NotasFiscais");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Telefone", b =>
                {
                    b.Property<int>("IdTelefone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTelefone"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DDI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTelefone");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Venda", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenda"));

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("IdVenda");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("DevIoBusiness.Models.VendaCarro", b =>
                {
                    b.Property<int>("IdVendaCarro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVendaCarro"));

                    b.Property<int>("IdCarro")
                        .HasColumnType("int");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdVendaCarro");

                    b.HasIndex("IdCarro");

                    b.HasIndex("IdVenda");

                    b.ToTable("VendaCarros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.VendaFormaPagamento", b =>
                {
                    b.Property<int>("IdVendaFormaPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVendaFormaPagamento"));

                    b.Property<int>("IdFormaPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("IdVendaFormaPagamento");

                    b.HasIndex("IdFormaPagamento");

                    b.HasIndex("IdVenda");

                    b.ToTable("VendaFormasPagamento");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Carro", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Modelo", "Modelo")
                        .WithMany("Carros")
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("DevIoBusiness.Models.CarroAdicionais", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Adicionais", null)
                        .WithMany("Carros")
                        .HasForeignKey("AdicionaisIdAdicionais");

                    b.HasOne("DevIoBusiness.Models.Adicionais", "Adicionais")
                        .WithMany()
                        .HasForeignKey("IdAdicionais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Carro", "Carro")
                        .WithMany("Adicionais")
                        .HasForeignKey("IdCarro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adicionais");

                    b.Navigation("Carro");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Cliente", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Telefone", "Telefone")
                        .WithMany()
                        .HasForeignKey("IdTelefone")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Endereco", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Cliente", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("DevIoBusiness.Models.Funcionario", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Funcionario", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Telefone", "Telefone")
                        .WithMany()
                        .HasForeignKey("IdTelefone")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Modelo", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("DevIoBusiness.Models.NotaFiscal", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Venda", "Venda")
                        .WithMany("NotasFiscais")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Telefone", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Cliente", null)
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId");

                    b.HasOne("DevIoBusiness.Models.Funcionario", null)
                        .WithMany("Telefones")
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Venda", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("DevIoBusiness.Models.VendaCarro", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Carro", "Carro")
                        .WithMany("VendaCarros")
                        .HasForeignKey("IdCarro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Venda", "Venda")
                        .WithMany("CarrosVendidos")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("DevIoBusiness.Models.VendaFormaPagamento", b =>
                {
                    b.HasOne("DevIoBusiness.Models.FormaPagamento", "FormaPagamento")
                        .WithMany("VendaFormasPagamento")
                        .HasForeignKey("IdFormaPagamento")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Venda", "Venda")
                        .WithMany("VendaFormasPagamento")
                        .HasForeignKey("IdVenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPagamento");

                    b.Navigation("Venda");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Adicionais", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Carro", b =>
                {
                    b.Navigation("Adicionais");

                    b.Navigation("VendaCarros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Cliente", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("DevIoBusiness.Models.FormaPagamento", b =>
                {
                    b.Navigation("VendaFormasPagamento");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Funcionario", b =>
                {
                    b.Navigation("Enderecos");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Modelo", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Venda", b =>
                {
                    b.Navigation("CarrosVendidos");

                    b.Navigation("NotasFiscais");

                    b.Navigation("VendaFormasPagamento");
                });
#pragma warning restore 612, 618
        }
    }
}
