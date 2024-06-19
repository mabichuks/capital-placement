namespace CapitalPlacement.Core.Models
{
    public record Answer
    {
        public string? QuestionId { get; set; }
        public string? Question { get; set; }
        public dynamic? Response { get; set; }
    }
}
