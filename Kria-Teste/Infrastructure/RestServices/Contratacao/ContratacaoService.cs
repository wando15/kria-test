using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Infrastructure.RestServices.Contratacao.Contracts;

namespace Infrastructure.RestServices.Contratacao
{
    public class ContratacaoService : RestClientService, IContratacaoService
    {
        private readonly ILogger<ContratacaoService> _logger;
        private readonly IConfiguration _configuration;
        public ContratacaoService(ILogger<ContratacaoService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public async Task ExecuteContratacaoAsync(int numeroArquivo, List<Transacao> transacoes, CancellationToken cancellationToken)
        {
            try
            {
                var apiUrl = _configuration.GetSection("KriaUsuarios:Url").Value;
                var endpoint = _configuration.GetSection("ContratacaoApi:Endpoint:PubliarDesafio").Value;
                var fullUrl = $"{apiUrl}/{endpoint}";
                var body = System.Text.Json.JsonSerializer.Serialize(new Envelope(numeroArquivo, transacoes));
                var response = await PostAsync<object>(fullUrl, System.Text.Json.JsonSerializer.Serialize(transacoes));
                _logger.LogInformation("Contratacao executed successfully. Response: {Response}", response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing Contratacao: {Message}", ex.Message);
                throw;
            }
        }
    }
}
