using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Commands
{
    public class ContratacaoCommand
    {
        private readonly ILogger<ContratacaoCommand> _logger;
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContratacaoService _contratacaoService;

        public ContratacaoCommand(ILogger<ContratacaoCommand> logger, ITransacaoRepository transacaoRepository, IContratacaoService contratacaoService)
        {
            _logger = logger;
            _transacaoRepository = transacaoRepository;
            _contratacaoService = contratacaoService;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Executing ContratacaoCommand...");
            var transacoes = await _transacaoRepository.GetAllAsync();
            _logger.LogInformation(" recovered {Count} transactions.", transacoes.Count);

            var i = 1;
            foreach (var transacao in transacoes.Chunk(1000).ToList())
            {
                _contratacaoService.ExecuteContratacaoAsync(i, new List<Transacao>(transacao), cancellationToken).Wait(cancellationToken);
                i++;
            }
        }
    }
}
