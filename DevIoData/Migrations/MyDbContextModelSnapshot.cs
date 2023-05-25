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

                    b.ToTable("CarroAdicionais");
                });

            modelBuilder.Entity("DevIoBusiness.Models.CarroCarroAdicionais", b =>
                {
                    b.Property<int>("IdCarro")
                        .HasColumnType("int");

                    b.Property<int>("IdAdicionais")
                        .HasColumnType("int");

                    b.Property<int?>("CarroAdicionaisIdAdicionais")
                        .HasColumnType("int");

                    b.HasKey("IdCarro", "IdAdicionais");

                    b.HasIndex("CarroAdicionaisIdAdicionais");

                    b.HasIndex("IdAdicionais");

                    b.ToTable("CarroCarroAdicionais");
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

            modelBuilder.Entity("DevIoBusiness.Models.Carro", b =>
                {
                    b.HasOne("DevIoBusiness.Models.Modelo", "Modelo")
                        .WithMany("Carros")
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("DevIoBusiness.Models.CarroCarroAdicionais", b =>
                {
                    b.HasOne("DevIoBusiness.Models.CarroAdicionais", null)
                        .WithMany("Carros")
                        .HasForeignKey("CarroAdicionaisIdAdicionais");

                    b.HasOne("DevIoBusiness.Models.CarroAdicionais", "CarroAdicionais")
                        .WithMany()
                        .HasForeignKey("IdAdicionais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevIoBusiness.Models.Carro", "Carro")
                        .WithMany("CarroAdicionais")
                        .HasForeignKey("IdCarro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("CarroAdicionais");
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

            modelBuilder.Entity("DevIoBusiness.Models.Carro", b =>
                {
                    b.Navigation("CarroAdicionais");
                });

            modelBuilder.Entity("DevIoBusiness.Models.CarroAdicionais", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("DevIoBusiness.Models.Modelo", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}
