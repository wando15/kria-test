using Domain.Interfaces.Services;
using Infrastructure.RestServices.Contratacao;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependenceInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddTransient<IContratacaoService, ContratacaoService>();
            return services;
        }
    }
}
