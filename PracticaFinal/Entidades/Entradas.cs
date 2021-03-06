﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PracticaFinal.Entidades
{
    public class Entradas
    {
        [Key]
        public int EntradaId { get; set; }
        public DateTime Fecha { get; set; }
        public int JuegoId { get; set; }
        public int Cantidad { get; set; }

        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            JuegoId = 0;
            Cantidad = 0;
        }
    }
}
