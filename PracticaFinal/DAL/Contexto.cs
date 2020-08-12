using Microsoft.EntityFrameworkCore;
using PracticaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticaFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Amigos> Amigos { get; set; }
        public DbSet<Entradas> Entradas { get; set; }
        public DbSet<Juegos> Juegos { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Prestamos> PrestamosDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source= DATA\BDPracticaFinal.db");
        }
    }
}
