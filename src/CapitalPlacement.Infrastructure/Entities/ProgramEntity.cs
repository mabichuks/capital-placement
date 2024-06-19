namespace CapitalPlacement.Infrastructure.Entities
{
    public record ProgramEntity
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public List<QuestionEntity> Questions { get; set; } = new();
    }
}
