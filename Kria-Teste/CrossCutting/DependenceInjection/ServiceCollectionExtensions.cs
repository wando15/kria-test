using Domain.Interfaces.Services;
using Infrastructure.RestServices.Contratacao;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependenceInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContratacaoService, ContratacaoService>();
            return services;
        }
    }
}
