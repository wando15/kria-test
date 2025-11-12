using Domain.Enums;

namespace Domain.Models
{
    public class Transacao : AggregateRoot
    {
        public Transacao()
        {
        }

        public Transacao(int idtransacao, DateTime dtcriacao, string codigopracapedagio, int codigocabine, string instante, SentidoEnum sentido, int quantidadeeixosveiculo, int rodagem, BinarioEnum isento, int motivoisencao, BinarioEnum evasao, int eixosuspenso, int quantidadeeixossuspensos, TipoCobrancaEfetuadaEnum tipocobranca, string placa, int liberacaocancela, decimal valordevido, decimal valorarrecadado, string cnpjamap, int veiculocarregado, string idtag) : base()
        {
            IdTransacao = idtransacao;
            DtCriacao = dtcriacao;
            CodigoPracaPedagio = codigopracapedagio;
            CodigoCabine = codigocabine;
            Instante = instante;
            Sentido = sentido;
            QuantidadeEixosVeiculo = quantidadeeixosveiculo;
            Rodagem = rodagem;
            Isento = isento;
            MotivoIsencao = motivoisencao;
            Evasao = evasao;
            EixoSuspenso = eixosuspenso;
            QuantidadeEixosSuspensos = quantidadeeixossuspensos;
            TipoCobranca = tipocobranca;
            Placa = placa;
            LiberacaoCancela = liberacaocancela;
            ValorDevido = valordevido;
            ValorArrecadado = valorarrecadado;
            CnpjAmap = cnpjamap;
            VeiculoCarregado = veiculocarregado;
            IdTag = idtag;

            ValidarMultiplicadorTarifa();
        }

        public int IdTransacao { get; set; }
        public DateTime DtCriacao { get; set; }
        public string? CodigoPracaPedagio { get; set; }
        public int CodigoCabine { get; set; }
        public string? Instante { get; set; }
        public SentidoEnum Sentido { get; set; }
        public BinarioEnum Isento { get; set; }
        public int MotivoIsencao { get; set; }
        public int Rodagem { get; set; }
        public BinarioEnum Evasao { get; set; }
        public int EixoSuspenso { get; set; }
        public int QuantidadeEixosSuspensos { get; set; }
        public int QuantidadeEixosVeiculo { get; set; }
        public TipoCobrancaEfetuadaEnum TipoCobranca { get; set; }
        public string? Placa { get; set; }
        public int LiberacaoCancela { get; set; }
        public decimal ValorDevido { get; set; }
        public decimal ValorArrecadado { get; set; }
        public string? CnpjAmap { get; set; }
        public decimal? MultiplicadorTarifa { get; set; }
        public int VeiculoCarregado { get; set; }
        public string? IdTag { get; set; }

        public TipoVeiculoEnum GetTipoVeiulo()
        {
            // Lógica de Validação:

            // Prioridade 1: Moto (Geralmente 2 eixos e 0 eixos suspensos)
            if (QuantidadeEixosVeiculo == 2 && QuantidadeEixosSuspensos == 0 && Rodagem == 1)
            {
                return TipoVeiculoEnum.Moto;
            }

            // Prioridade 2: Comercial (Possui eixos suspensos ou mais de 2 eixos)
            // EixoSuspenso == 1 geralmente indica que o veículo TEM a capacidade de suspender eixo.
            if (EixoSuspenso == 1 || QuantidadeEixosSuspensos > 0 || QuantidadeEixosVeiculo > 2)
            {
                return TipoVeiculoEnum.Comercial;
            }

            // Prioridade 3: Passeio (Geralmente 4 rodas/2 eixos, sem eixos suspensos)
            // Isso engloba carros e caminhonetes de uso comum.
            if (QuantidadeEixosVeiculo <= 2 && QuantidadeEixosSuspensos == 0)
            {
                return TipoVeiculoEnum.Passeio;
            }

            // Caso padrão ou se a lógica não cobrir (pode ser ajustado conforme necessário)
            return TipoVeiculoEnum.Passeio;
        }

        public void ValidarMultiplicadorTarifa()
        {
            switch (GetTipoVeiulo())
            {
                case TipoVeiculoEnum.Moto:
                    {
                        if (Isento == BinarioEnum.Sim)
                            MultiplicadorTarifa = 0;
                        else
                            MultiplicadorTarifa = 0.5m;

                        break;
                    }
                case TipoVeiculoEnum.Passeio:
                    {
                        decimal[] valoresPasseio = { 1.0m, 1.5m, 2.0m };
                        MultiplicadorTarifa = valoresPasseio[new Random().Next(0, valoresPasseio.Length)];
                        break;
                    }
                case TipoVeiculoEnum.Comercial:
                    {
                        MultiplicadorTarifa = new Random().Next(2, 20);
                        break;
                    }
                default:
                    {
                        MultiplicadorTarifa = 0m;
                        break;
                    }
            }
        }
    }
}
