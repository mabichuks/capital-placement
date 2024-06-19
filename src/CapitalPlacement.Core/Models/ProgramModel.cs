using System.Text.Json.Serialization;

namespace CapitalPlacement.Core.Models
{
    public record ProgramModel
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public List<Question> Questions { get; set; } = new();
    }
}
