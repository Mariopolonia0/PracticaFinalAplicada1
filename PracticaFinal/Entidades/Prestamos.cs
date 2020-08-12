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
        public virtual List<PrestamosDetalle> PrestamoDetalle { get; set; }

    }

    public class PrestamosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int JuegoId { get; set; }
        public int Cantidad { get; set; }
    }
}
//Prestamos (PrestamoId,Fecha,AmigoId, Observacion, CantidadJuegos)
//PrestamosDetalle(Id, PrestamoId, JuegoId, Cantidad)