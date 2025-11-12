using Domain.Enums;
using Domain.Models;
using FluentAssertions;

namespace Kria_Tests.UnitTests.Domain.DomainTests
{
    public class TransacaoTests
    {
        [Fact(DisplayName = "Deve validas as regras de Multiplicador de tarifa Moto Isento com Sucesso")]
        public void DeveValidasRegrasDeMultiplicadorDeTarifaMotoIsentoComSucesso()
        {

            var quantidadeEixosVeiculo = 2;
            var eixoSuspenso = 0;
            var quantidadeEixosSuspensos = 0;
            var rodagem = 1;    

            var transacao = new Transacao(286295, DateTime.Now, "0197", 2379, "02/03/2022 07:42:18 -03:00", SentidoEnum.Decrescente, quantidadeEixosVeiculo, rodagem, BinarioEnum.Sim, 0, BinarioEnum.Sim, eixoSuspenso, quantidadeEixosSuspensos, TipoCobrancaEfetuadaEnum.Tag, "FJP7A55", 1, 16, 16, "04088208000165", 3, "0727253043");

            transacao.MultiplicadorTarifa.Should().NotBeNull();
            transacao.MultiplicadorTarifa.Should().Be(0);
        }

        [Fact(DisplayName = "Deve validas as regras de Multiplicador de tarifa Moto Não Isento com Sucesso")]
        public void DeveValidasRegrasDeMultiplicadorDeTarifaMotoNaoIsentoComSucesso()
        {

            var quantidadeEixosVeiculo = 2;
            var eixoSuspenso = 0;
            var quantidadeEixosSuspensos = 0;
            var rodagem = 1;

            var transacao = new Transacao(286295, DateTime.Now, "0197", 2379, "02/03/2022 07:42:18 -03:00", SentidoEnum.Decrescente, quantidadeEixosVeiculo, rodagem, BinarioEnum.Nao, 0, BinarioEnum.Sim, eixoSuspenso, quantidadeEixosSuspensos, TipoCobrancaEfetuadaEnum.Tag, "FJP7A55", 1, 16, 16, "04088208000165", 3, "0727253043");

            transacao.MultiplicadorTarifa.Should().NotBeNull();
            transacao.MultiplicadorTarifa.Should().Be(0.5m);
        }

        [Fact(DisplayName = "Deve validas as regras de Multiplicador de tarifa Passeio com Sucesso")]
        public void DeveValidasRegrasDeMultiplicadorDeTarifaPasseioComSucesso()
        {

            var quantidadeEixosVeiculo = 2;
            var eixoSuspenso = 0;
            var quantidadeEixosSuspensos = 0;
            var rodagem = 5;

            var transacao = new Transacao(286295, DateTime.Now, "0197", 2379, "02/03/2022 07:42:18 -03:00", SentidoEnum.Decrescente, quantidadeEixosVeiculo, rodagem, BinarioEnum.Nao, 0, BinarioEnum.Sim, eixoSuspenso, quantidadeEixosSuspensos, TipoCobrancaEfetuadaEnum.Tag, "FJP7A55", 1, 16, 16, "04088208000165", 3, "0727253043");

            transacao.MultiplicadorTarifa.Should().NotBeNull();
            transacao.MultiplicadorTarifa.Should().BePositive();
        }

        [Fact(DisplayName = "Deve validas as regras de Multiplicador de tarifa comercial com Sucesso")]
        public void DeveValidasRegrasDeMultiplicadorDeTarifaComercialComSucesso()
        {

            var quantidadeEixosVeiculo = 2;
            var eixoSuspenso = 1;
            var quantidadeEixosSuspensos = 2;
            var rodagem = 2;

            var transacao = new Transacao(286295, DateTime.Now, "0197", 2379, "02/03/2022 07:42:18 -03:00", SentidoEnum.Decrescente, quantidadeEixosVeiculo, rodagem, BinarioEnum.Nao, 0, BinarioEnum.Sim, eixoSuspenso, quantidadeEixosSuspensos, TipoCobrancaEfetuadaEnum.Tag, "FJP7A55", 1, 16, 16, "04088208000165", 3, "0727253043");

            transacao.MultiplicadorTarifa.Should().NotBeNull();
            transacao.MultiplicadorTarifa.Should().BeInRange(2, 20);
        }

        [Fact(DisplayName = "Deve validas as regras de Tipo de Veiculo Moto com Sucesso")]
        public void DeveValidasRegrasDeTipoDeVeiculoMotoComSucesso()
        {
            // Arrange
            var transacao = new Transacao()
            {
                Id = new MongoDB.Bson.ObjectId(),
                IdTransacao = 286295,
                DtCriacao = DateTime.Now,
                CodigoPracaPedagio = "0197",
                CodigoCabine = 2379,
                Instante = "02/03/2022 07:42:18 -03:00",
                Sentido = SentidoEnum.Decrescente,
                Isento = BinarioEnum.Sim,
                MotivoIsencao = 0,
                Evasao = BinarioEnum.Sim,
                EixoSuspenso = 0,
                QuantidadeEixosVeiculo = 2,
                QuantidadeEixosSuspensos = 0,
                Rodagem = 1,
                TipoCobranca = TipoCobrancaEfetuadaEnum.Tag,
                Placa = "FJP7A55",
                LiberacaoCancela = 1,
                ValorDevido = 16,
                ValorArrecadado = 16,
                CnpjAmap = "04088208000165",
                MultiplicadorTarifa = null,
                VeiculoCarregado = 3,
                IdTag = "0727253043"
            };

            transacao.GetTipoVeiulo().Should().Be(TipoVeiculoEnum.Moto);
        }

        [Fact(DisplayName = "Deve validas as regras de Tipo de Veiculo Passeio com Sucesso")]
        public void DeveValidasRegrasDeTipoDeVeiculoPasseioComSucesso()
        {
            // Arrange
            var transacao = new Transacao()
            {
                Id = new MongoDB.Bson.ObjectId(),
                IdTransacao = 286295,
                DtCriacao = DateTime.Now,
                CodigoPracaPedagio = "0197",
                CodigoCabine = 2379,
                Instante = "02/03/2022 07:42:18 -03:00",
                Sentido = SentidoEnum.Decrescente,
                Isento = BinarioEnum.Sim,
                MotivoIsencao = 0,
                Evasao = BinarioEnum.Sim,
                EixoSuspenso = 0,
                QuantidadeEixosVeiculo = 2,
                QuantidadeEixosSuspensos = 0,
                Rodagem = 5,
                TipoCobranca = TipoCobrancaEfetuadaEnum.Tag,
                Placa = "FJP7A55",
                LiberacaoCancela = 1,
                ValorDevido = 16,
                ValorArrecadado = 16,
                CnpjAmap = "04088208000165",
                MultiplicadorTarifa = null,
                VeiculoCarregado = 3,
                IdTag = "0727253043"
            };

            transacao.GetTipoVeiulo().Should().Be(TipoVeiculoEnum.Passeio);
        }

        [Fact(DisplayName = "Deve validas as regras de Tipo de Veiculo Comercial com Sucesso")]
        public void DeveValidasRegrasDeTipoDeVeiculoComercialComSucesso()
        {
            // Arrange
            var transacao = new Transacao()
            {
                Id = new MongoDB.Bson.ObjectId(),
                IdTransacao = 286295,
                DtCriacao = DateTime.Now,
                CodigoPracaPedagio = "0197",
                CodigoCabine = 2379,
                Instante = "02/03/2022 07:42:18 -03:00",
                Sentido = SentidoEnum.Decrescente,
                Isento = BinarioEnum.Sim,
                MotivoIsencao = 0,
                Evasao = BinarioEnum.Sim,
                EixoSuspenso = 1,
                QuantidadeEixosSuspensos = 1,
                QuantidadeEixosVeiculo = 3,
                Rodagem = 5,
                TipoCobranca = TipoCobrancaEfetuadaEnum.Tag,
                Placa = "FJP7A55",
                LiberacaoCancela = 1,
                ValorDevido = 16,
                ValorArrecadado = 16,
                CnpjAmap = "04088208000165",
                MultiplicadorTarifa = null,
                VeiculoCarregado = 3,
                IdTag = "0727253043"
            };

            transacao.GetTipoVeiulo().Should().Be(TipoVeiculoEnum.Comercial);
        }
    }
}
