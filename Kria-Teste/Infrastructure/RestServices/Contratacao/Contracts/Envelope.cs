using Domain.Models;
using Domain.Utils;

namespace Infrastructure.RestServices.Contratacao.Contracts
{
    public class Envelope
    {
        public Envelope(int numeroArquivo, List<Transacao> transacoes)
        {
            DataReferencia = DateTime.Now.ToString("dd/MM/yyyy");
            NumeroArquivo = numeroArquivo;
            Candidato = "Wanderson Cesario Nascimento Souza";
            AddRegistros(transacoes);
        }

        public string DataReferencia { get; set; }
        public int NumeroArquivo { get; set; }
        public List<Registro> Registros { get; set; }
        public string Candidato { get; set; }

        public void AddRegistros(List<Transacao> transacoes)
        {
            Registros = new List<Registro>();
            foreach (var transacao in transacoes)
            {
                Registros.Add(new Registro()
                {
                    Guid = transacao.Id.ToString(),
                    CodigoPracaPedagio = transacao.CodigoPracaPedagio,
                    CodigoCabine = transacao.CodigoCabine.ToString(),
                    Instante = transacao.Instante,
                    Sentido = transacao.Sentido.GetEnumDescription(),
                    TipoVeiculo = transacao.GetTipoVeiulo().GetEnumDescription(),
                    Isento = transacao.Isento.GetEnumDescription(),
                    Evasao = transacao.Evasao.GetEnumDescription(),
                    TipoCobrancaEfetuada = transacao.TipoCobranca.GetEnumDescription(),
                    ValorDevido = transacao.ValorDevido.ToString("F2"),
                    ValorArrecadado = transacao.ValorArrecadado.ToString("F2"),
                    MultiplicadorTarifa = transacao.MultiplicadorTarifa.ToString("F2"),
                });
            }
        }
    }
}
