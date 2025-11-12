using Application.Commands;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace Kria_Tests.UnitTests.ApplicaionTests.Commands
{
    public class ContratacaoCommandTest
    {
        private readonly Mock<ILogger<ContratacaoCommand>> _logger;
        private readonly Mock<ITransacaoRepository> _transacaoRepository;
        private readonly Mock<IContratacaoService> _contratacaoService;

        public ContratacaoCommandTest()
        {
            _logger = new Mock<ILogger<ContratacaoCommand>>();
            _transacaoRepository = new Mock<ITransacaoRepository>();
            _contratacaoService = new Mock<IContratacaoService>();
        }

        [Fact(DisplayName = "Deve executar o comando de contratacao com sucesso")]
        public async Task DeveExecutarComandoContratacaoComSucesso()
        {
            var transacoes = new List<Transacao>
            {
                new() {
                    Id = new MongoDB.Bson.ObjectId(),
                    IdTransacao = 286295,
                    DtCriacao = DateTime.Now,
                    CodigoPracaPedagio = "0197",
                    CodigoCabine = 2379,
                    Instante = "02/03/2022 07:42:18 -03:00",
                    Sentido = SentidoEnum.Decrescente,
                    QuantidadeEixosVeiculo = 5,
                    Rodagem = 2,
                    Isento = BinarioEnum.Sim,
                    MotivoIsencao = 0,
                    Evasao = BinarioEnum.Sim,
                    EixoSuspenso = 2,
                    QuantidadeEixosSuspensos = 0,
                    TipoCobranca = TipoCobrancaEfetuadaEnum.Tag,
                    Placa = "FJP7A55",
                    LiberacaoCancela = 1,
                    ValorDevido = 16,
                    ValorArrecadado = 16,
                    CnpjAmap = "04088208000165",
                    MultiplicadorTarifa = null,
                    VeiculoCarregado = 3,
                    IdTag = "0727253043"
                }
            };

            _transacaoRepository.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(transacoes));

            _contratacaoService.Setup(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny<CancellationToken>()));

            var command = new ContratacaoCommand(_logger.Object, _transacaoRepository.Object, _contratacaoService.Object);
            await command.ExecuteAsync(CancellationToken.None);

            _transacaoRepository.Verify(x => x.GetAllAsync(), Times.Once);
            _contratacaoService.Verify(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact(DisplayName = "Deve executar o comando de contratacao com Sucesso sem transações")]
        public async Task DeveExecutarComandoContratacaoComSucessoSemTransacoes()
        {
            _transacaoRepository.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(new List<Transacao>()));

            _contratacaoService.Setup(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny<CancellationToken>())).Throws(new Exception());

            var command = new ContratacaoCommand(_logger.Object, _transacaoRepository.Object, _contratacaoService.Object);
            await command.ExecuteAsync(CancellationToken.None);

            _transacaoRepository.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Fact(DisplayName = "Deve executar o comando de contratacao com Erro")]
        public async Task DeveExecutarComandoContratacaoComErro()
        {
            var transacoes = new List<Transacao>
            {
                new() {
                    Id = new MongoDB.Bson.ObjectId(),
                    IdTransacao = 286295,
                    DtCriacao = DateTime.Now,
                    CodigoPracaPedagio = "0197",
                    CodigoCabine = 2379,
                    Instante = "02/03/2022 07:42:18 -03:00",
                    Sentido = SentidoEnum.Decrescente,
                    QuantidadeEixosVeiculo = 5,
                    Rodagem = 2,
                    Isento = BinarioEnum.Sim,
                    MotivoIsencao = 0,
                    Evasao = BinarioEnum.Sim,
                    EixoSuspenso = 2,
                    QuantidadeEixosSuspensos = 0,
                    TipoCobranca = TipoCobrancaEfetuadaEnum.Tag,
                    Placa = "FJP7A55",
                    LiberacaoCancela = 1,
                    ValorDevido = 16,
                    ValorArrecadado = 16,
                    CnpjAmap = "04088208000165",
                    MultiplicadorTarifa = null,
                    VeiculoCarregado = 3,
                    IdTag = "0727253043"
                }
            };

            _transacaoRepository.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(transacoes));

            _contratacaoService.Setup(x => x.ExecuteContratacaoAsync(It.IsAny<int>(), It.IsAny<List<Transacao>>(), It.IsAny<CancellationToken>())).Throws(new Exception());

            var command = new ContratacaoCommand(_logger.Object, _transacaoRepository.Object, _contratacaoService.Object);
            await Assert.ThrowsAsync<Exception>(async () => await command.ExecuteAsync(CancellationToken.None));
        }
    }
}
