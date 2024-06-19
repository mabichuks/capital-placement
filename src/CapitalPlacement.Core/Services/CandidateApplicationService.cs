using CapitalPlacement.Core.Exceptions;
using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;


namespace CapitalPlacement.Core.Services
{
    public class CandidateApplicationService
    {
        private readonly ICandidateApplicationRepository _repo;
        public CandidateApplicationService(ICandidateApplicationRepository repo)
        {
            _repo = repo;
        }
        public async Task<CandidateApplication> GetCandidateApplicationByIdAsync(string id)
        {
            var response = await _repo.GetById(id);
            if (response == null) throw new NotFoundException($"Application with Id {id} not found");
            return response;
        }

        public async Task<CandidateApplication> SubmitCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            var response = await _repo.Add(candidateApplication);
            return response;
        }
    }
}
