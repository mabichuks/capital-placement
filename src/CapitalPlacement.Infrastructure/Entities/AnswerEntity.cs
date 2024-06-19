namespace CapitalPlacement.Infrastructure.Entities
{
    public record AnswerEntity
    {
        public string? QuestionId { get; set; }
        public string? Question { get; set; }
        public string? Response { get; set; }
    }
}
