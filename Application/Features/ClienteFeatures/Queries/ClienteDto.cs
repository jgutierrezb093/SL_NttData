using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using FluentValidation;

namespace Application.Features.ClienteFeatures.Queries
{
    public class ClienteDto
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public Generos Genero { get; set; }
        public short Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
