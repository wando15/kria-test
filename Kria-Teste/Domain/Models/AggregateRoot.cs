using System.Text.Json.Serialization;
using MongoDB.Bson; // Adiciona o using necessário para ObjectId

namespace Domain.Models
{
    public class AggregateRoot
    {
        [JsonPropertyName("_id")]
        public ObjectId Id { get; set; }
    }
}
