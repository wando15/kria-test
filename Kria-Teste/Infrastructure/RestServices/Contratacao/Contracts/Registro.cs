using System.Text.Json.Serialization;

namespace Infrastructure.RestServices.Contratacao.Contracts
{
    public class Registro
    {
        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("codigoPracaPedagio")]
        public string CodigoPracaPedagio { get; set; }

        [JsonPropertyName("codigoCabine")]
        public int CodigoCabine { get; set; }

        [JsonPropertyName("instante")]
        public string Instante { get; set; }

        [JsonPropertyName("sentido")]
        public string Sentido { get; set; }

        [JsonPropertyName("tipoVeiculo")]
        public string TipoVeiculo { get; set; }

        [JsonPropertyName("isento")]
        public string Isento { get; set; }

        [JsonPropertyName("evasao")]
        public string Evasao { get; set; }

        [JsonPropertyName("tipoCobrancaEfetuada")]
        public string TipoCobrancaEfetuada { get; set; }

        [JsonPropertyName("valorDevido")]
        public string ValorDevido { get; set; }

        [JsonPropertyName("valorArrecadado")]
        public string ValorArrecadado { get; set; }

        [JsonPropertyName("multiplicadorTarifa")]
        public decimal MultiplicadorTarifa { get; set; }
    }
}
