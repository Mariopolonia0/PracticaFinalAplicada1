using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PracticaFinal.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public int AmigoId { get; set; }
        public string Observacion { get; set; }
        public int CantidadJuegos { get; set; }

        [ForeignKey("PrestamoId")]
        public virtual List<PrestamosDetalles> PrestamoDetalle { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Fecha = DateTime.Now;
            AmigoId = 0;
            Observacion = string.Empty;
            CantidadJuegos = 0;
            PrestamoDetalle = new List<PrestamosDetalles>();
        }
    }
}
