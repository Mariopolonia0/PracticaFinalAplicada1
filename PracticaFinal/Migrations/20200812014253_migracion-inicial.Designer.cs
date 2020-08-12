﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PracticaFinal.DAL;

namespace PracticaFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200812014253_migracion-inicial")]
    partial class migracioninicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("PracticaFinal.Entidades.Amigos", b =>
                {
                    b.Property<int>("AmigoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Celular")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("AmigoId");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("PracticaFinal.Entidades.Entradas", b =>
                {
                    b.Property<int>("EntradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("JuegoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntradaId");

                    b.ToTable("Entradas");
                });

            modelBuilder.Entity("PracticaFinal.Entidades.Juegos", b =>
                {
                    b.Property<int>("JuegoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("JuegoId");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("PracticaFinal.Entidades.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AmigoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadJuegos")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacion")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("PracticaFinal.Entidades.PrestamosDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JuegoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PrestamoId");

                    b.ToTable("PrestamosDetalle");
                });

            modelBuilder.Entity("PracticaFinal.Entidades.PrestamosDetalle", b =>
                {
                    b.HasOne("PracticaFinal.Entidades.Prestamos", null)
                        .WithMany("PrestamoDetalle")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
