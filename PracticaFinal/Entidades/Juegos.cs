using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaFinal.Entidades
{
    public class Juegos
    {
        [Key]
        public int JuegoId { get; set; }
        public DateTime FechaCompra { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }

        public Juegos()
        {
            JuegoId = 0;
            FechaCompra = DateTime.Now;
            Descripcion = string.Empty;
            Precio = 0;
            Existencia = 0;
        } 
    }
}
