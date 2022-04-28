using Application.Interfaces;
using Domain.Entity;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(NttDataDbContext context) : base(context)
        {
        }
    }
}
