using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IContratacaoService
    {
        Task ExecuteContratacaoAsync(int numeroArquivo, List<Transacao> transacoes, CancellationToken cancellationToken);
    }
}
