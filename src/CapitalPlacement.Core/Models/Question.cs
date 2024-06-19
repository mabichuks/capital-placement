using System.Text.Json.Serialization;

namespace CapitalPlacement.Core.Models
{
    public record Question
    {
        public string? Id { get; set; }
        public required string Text { get; set; }
        public string? ProgramEntityId { get; set; }
        public required QuestionType QuestionType { get; set; }
        public bool IsMandatory { get; set; } = false;
        public bool IsInternal { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool HasOther { get; set; } = false;
        public bool IsPersonalInformaton { get; set; } = true;
        public bool AllowMultiSelect { get; set; } = false;
        public List<string> Options { get; set; } = new();
        public int MaxLength { get; set; } = 500;
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 10;
    }
}
