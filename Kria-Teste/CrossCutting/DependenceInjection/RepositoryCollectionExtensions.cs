using Domain.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependenceInjection
{
    public static class RepositoryCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
        }
    }
}
