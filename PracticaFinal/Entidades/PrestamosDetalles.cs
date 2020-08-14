using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaFinal.Entidades
{
    public class PrestamosDetalles
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int JuegoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }

        public PrestamosDetalles()
        {
            Id = 0;
            PrestamoId = 0;
            JuegoId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
        }

        public PrestamosDetalles(int prestamoid, int juegosid, int cantidad, string descripcion)
        {
            Id = PrestamoId = prestamoid;
            //PrestamoId = prestamoid;
            JuegoId = juegosid;
            Cantidad = cantidad;
            Descripcion = descripcion;
        }
    }
}
