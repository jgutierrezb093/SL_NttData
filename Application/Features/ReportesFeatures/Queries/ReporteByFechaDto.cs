using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ReportesFeatures.Queries
{
    public class ReporteByFechaDto
    {
        public string? Fecha { get; set; }
        public string? Cliente { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
        public decimal? Movimiento { get; set; }
        public decimal? SaldoDisponible { get; set; }
    }
}
