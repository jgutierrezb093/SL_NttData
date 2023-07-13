using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface INttDataDbContext
    {
        DbSet<Cliente> Cliente { get; set; }
    }
}
