using Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ContratacaoService
{
    public class ContratacaoWorkerService : BackgroundService
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<ContratacaoWorkerService> _logger;

        public ContratacaoWorkerService(IServiceProvider provider, ILogger<ContratacaoWorkerService> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Init run Service");
            using var scope = _provider.CreateScope();
            var cmd = scope.ServiceProvider.GetRequiredService<ContratacaoCommand>();
            await cmd.ExecuteAsync(stoppingToken);
            _logger.LogInformation("Finish run Service");
        }
    }
}
