using Microsoft.Extensions.DependencyInjection;
using Application.Commands;

namespace CrossCutting.DependenceInjection
{
    public static class CommandCollectionExtensions
    {
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<ContratacaoCommand>();
        }
    }
}
