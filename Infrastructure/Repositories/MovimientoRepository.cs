using Application.Interfaces;
using Domain.Entity;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class MovimientoRepository : Repository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(NttDataDbContext context) : base(context)
        {
        }
    }
}
