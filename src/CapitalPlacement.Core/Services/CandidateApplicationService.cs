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
        //public async Task<CandidateApplication> GetCandidateApplicationByIdAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<CandidateApplication>> GetCandidateApplicationsAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<CandidateApplication> SubmitCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            var response = await _repo.Add(candidateApplication);
            return response;
        }
    }
}
