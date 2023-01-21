﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcWebGradesApplication.Data;

#nullable disable

namespace MvcWebGradesApplication.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MvcWebGradesApplication.Models.FormadorModel", b =>
                {
                    b.Property<long>("Nif")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Nif"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nif");

                    b.ToTable("Formadores");
                });

            modelBuilder.Entity("MvcWebGradesApplication.Models.FormandoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Formandos");
                });

            modelBuilder.Entity("MvcWebGradesApplication.Models.NotaModel", b =>
                {
                    b.Property<int>("FormandoId")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUfcd")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLancamentoNota")
                        .HasColumnType("datetime2");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.HasKey("FormandoId", "CodigoUfcd");

                    b.HasIndex("CodigoUfcd");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("MvcWebGradesApplication.Models.UfcdModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"), 1L, 1);

                    b.Property<int>("Componente")
                        .HasColumnType("int");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<long>("FormadorNif")
                        .HasColumnType("bigint");

                    b.Property<string>("Ufcd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("FormadorNif");

                    b.ToTable("Ufcds");
                });

            modelBuilder.Entity("MvcWebGradesApplication.Models.NotaModel", b =>
                {
                    b.HasOne("MvcWebGradesApplication.Models.UfcdModel", "Ufcd")
                        .WithMany()
                        .HasForeignKey("CodigoUfcd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcWebGradesApplication.Models.FormandoModel", "Formando")
                        .WithMany()
                        .HasForeignKey("FormandoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formando");

                    b.Navigation("Ufcd");
                });

            modelBuilder.Entity("MvcWebGradesApplication.Models.UfcdModel", b =>
                {
                    b.HasOne("MvcWebGradesApplication.Models.FormadorModel", "Formador")
                        .WithMany()
                        .HasForeignKey("FormadorNif")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Formador");
                });
#pragma warning restore 612, 618
        }
    }
}
