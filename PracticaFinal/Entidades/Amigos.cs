using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaFinal.Entidades
{
    public class Amigos
    {
        [Key]
        public int AmigoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Amigos()
        {
            AmigoId = 0;
            Nombre = string.Empty; 
            Direccion = string.Empty;
            Celular = string.Empty;
            Celular = string.Empty;
            Email = string.Empty;
            FechaNacimiento = DateTime.UtcNow;
        }
    }
}
