using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class AggregateRoot
    {
        [property: JsonPropertyName("_id")]
        public Guid Id { get; set; }
    }
}
