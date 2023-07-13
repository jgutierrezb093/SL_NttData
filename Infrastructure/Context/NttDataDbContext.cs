using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entity;

namespace Infrastructure.Context
{
    public class NttDataDbContext : DbContext, INttDataDbContext
    {
        public NttDataDbContext(DbContextOptions<NttDataDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
