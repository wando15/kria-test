using Domain.Enums;

namespace Domain.Models
{
    public class Transacao : AggregateRoot
    {
        public Transacao()
        {
            GetMultiplicadorTarifa();
        }

        public Transacao(int idtransacao, DateTime dtcriacao, string codigopracapedagio, int codigocabine, string instante, SentidoEnum sentido, int quantidadeeixosveiculo, int rodagem, BinarioEnum isento, int motivoisencao, BinarioEnum evasao, int eixosuspenso, int quantidadeeixossuspensos, TipoCobrancaEfetuadaEnum tipocobranca, string placa, int liberacaocancela, decimal valordevido, decimal valorarrecadado, string cnpjamap, string multiplicadortarifa, int veiculocarregado, string idtag) : base()
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

        }

        public int IdTransacao { get; set; }
        public DateTime DtCriacao { get; set; }
        public string CodigoPracaPedagio { get; set; }
        public int CodigoCabine { get; set; }
        public string Instante { get; set; }
        public SentidoEnum Sentido { get; set; }
        public int QuantidadeEixosVeiculo { get; set; }
        public int Rodagem { get; set; }
        public BinarioEnum Isento { get; set; }
        public int MotivoIsencao { get; set; }
        public BinarioEnum Evasao { get; set; }
        public int EixoSuspenso { get; set; }
        public int QuantidadeEixosSuspensos { get; set; }
        public TipoCobrancaEfetuadaEnum TipoCobranca { get; set; }
        public string Placa { get; set; }
        public int LiberacaoCancela { get; set; }
        public decimal ValorDevido { get; set; }
        public decimal ValorArrecadado { get; set; }
        public string CnpjAmap { get; set; }
        public decimal MultiplicadorTarifa { get; set; }
        public int VeiculoCarregado { get; set; }
        public string IdTag { get; set; }

        public TipoVeiculoEnum GetTipoVeiulo()
        {
            if (QuantidadeEixosVeiculo == 2 && Rodagem == 2)
                return TipoVeiculoEnum.Moto;
            else if (QuantidadeEixosVeiculo <= 2)
                return TipoVeiculoEnum.Passeio;
            else
                return TipoVeiculoEnum.Comercial;
        }

        public void GetMultiplicadorTarifa()
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
                        MultiplicadorTarifa = new Random().Next(0, valoresPasseio.Length);
                        break;
                    }
                case TipoVeiculoEnum.Comercial:
                    {
                        MultiplicadorTarifa = new Random().Next(2, 20);
                        break;
                    }
            }           
        }
    }
}
