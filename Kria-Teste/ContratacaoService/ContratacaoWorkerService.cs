using Application.Commands;

namespace ContratacaoService
{
    public class ContratacaoWorkerService : BackgroundService
    {
        private readonly ILogger<ContratacaoWorkerService> _logger;
        private readonly ContratacaoCommand _contratacaoCommand;

        public ContratacaoWorkerService(ILogger<ContratacaoWorkerService> logger, ContratacaoCommand contratacaoCommand)
        {
            _logger = logger;
            _contratacaoCommand = contratacaoCommand;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _contratacaoCommand.ExecuteAsync(cancellationToken);
            }
        }
    }
}
