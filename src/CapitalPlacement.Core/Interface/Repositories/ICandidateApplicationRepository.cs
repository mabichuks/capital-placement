using CapitalPlacement.Core.Models;

namespace CapitalPlacement.Core.Interface.Repositories
{
    public interface ICandidateApplicationRepository
    {
        Task<CandidateApplication?> GetById(string id);
        Task<CandidateApplication> Add(CandidateApplication candidateApplication);
    }
}
