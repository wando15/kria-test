using Domain.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.ConfigurationRoot;

namespace Infrastructure.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MongoDbContext context) : base(context)
        {
        }
    }
}
