using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Persona : BaseEntity
    {
        public string? Nombre { get; set; }
        public Generos Genero { get; set; }
        public short Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
