using System.Text.Json.Serialization;

namespace CapitalPlacement.Core.Models
{
    public record Question
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Text { get; set; }
        public string? ProgramEntityId { get; set; }
        public QuestionType QuestionType { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
        public bool HasOther { get; set; }
        public bool IsPersonalInformaton { get; set; }
        public bool AllowMultiSelect { get; set; }
        public List<string> Options { get; set; } = new();
        public int MaxLength { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
