using Application.Commands;
using Domain.Interfaces.Services;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace Kria_Tests.UnitTests.ApplicaionTests.Commands
{
    public class ContratacaoCommandTest
    {
        private readonly Mock<ILogger<ContratacaoCommand>> _logger;
        private readonly Mock<TransacaoRepository> _transacaoRepository;
        private readonly Mock<IContratacaoService> _contratacaoService;
        private readonly ContratacaoCommand _command;

        public ContratacaoCommandTest()
        {
            _logger = new Mock<ILogger<ContratacaoCommand>>();
            _transacaoRepository = new Mock<TransacaoRepository>();
            _contratacaoService = new Mock<IContratacaoService>();
            _command = new ContratacaoCommand(_logger.Object, _transacaoRepository.Object, _contratacaoService.Object);
        }

        [Fact(DisplayName = "Deve executar o comando de contratacao com sucesso")]
        public async Task DeveExecutarComandoContratacaoComSucesso()
        {
            var transacoes = Utils.Utils.ReadFile<List<Transacao>>("UnitTests/ApplicaionTests/Commands/Mocks/TransacoesMock.json");

            _transacaoRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(transacoes);
            _contratacaoService.Setup(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny<CancellationToken>()));
            
            await _command.ExecuteAsync(CancellationToken.None);

            _transacaoRepository.Verify(x => x.GetAllAsync(), Times.Once);
            _contratacaoService.Verify(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny< CancellationToken>()), Times.Exactly(2));
        }
    }
}
