using CapitalPlacement.Core.Models;

namespace CapitalPlacement.Core.Interface.Services
{
    public interface ICandidateApplicationService
    {
        Task<IEnumerable<CandidateApplication>> GetCandidateApplicationsAsync();
        Task<CandidateApplication> GetCandidateApplicationByIdAsync();
        Task<CandidateApplication> SubmitCandidateApplicationAsync(CandidateApplication candidateApplication);
    }
}
