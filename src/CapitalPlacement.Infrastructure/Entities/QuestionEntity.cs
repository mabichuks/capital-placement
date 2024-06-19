using Newtonsoft.Json;

namespace CapitalPlacement.Infrastructure.Entities
{
    public record QuestionEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
        public string? ProgramEntityId { get; set; }
        public string? Text { get; set; }
        public string? QuestionType { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsInternal { get; set; }
        public bool IsHidden { get; set; }
        public bool HasOther { get; set; }
        public bool AllowMultiSelect { get; set; }
        public bool IsPersonalInformaton { get; set; }
        public List<string> Options { get; set; } = new();
        public int MaxLength { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

    }
}
