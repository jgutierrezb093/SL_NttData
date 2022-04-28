using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Cuenta : BaseEntity
    {
        public string? NumeroCuenta { get; set; }
        public TipoCuentas TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public IEnumerable<Movimiento>? Movimientos { get; set; }
    }
}
