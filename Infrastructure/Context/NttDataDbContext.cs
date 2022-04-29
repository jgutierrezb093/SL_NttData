using Microsoft.EntityFrameworkCore;
using System;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Infrastructure.Context
{
    public class NttDataDbContext : DbContext, INttDataDbContext
    {
        public NttDataDbContext(DbContextOptions<NttDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cuentas)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.Property(e => e.Saldo).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Cuenta)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CuentaId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
