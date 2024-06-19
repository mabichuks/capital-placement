namespace CapitalPlacement.Infrastructure.Entities
{
    public record CandidateApplicationEntity
    {
        public string? Id { get; set; }
        public List<AnswerEntity> Answers { get; set; } = new();
    }
}
