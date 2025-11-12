using Microsoft.Extensions.DependencyInjection;
using Application.Commands;
using Domain.Interfaces.Commands;

namespace CrossCutting.DependenceInjection
{
    public static class CommandCollectionExtensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ContratacaoCommand>();
            return services;
        }
    }
}
