using System.Text.Json.Serialization;

namespace CapitalPlacement.Core.Models
{
    public record CandidateApplication
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public List<Answer> Answers { get; set; } = new();
    }
}
