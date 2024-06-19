using CapitalPlacement.Core.Exceptions;
using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;
using System.ComponentModel.DataAnnotations;


namespace CapitalPlacement.Core.Services
{
    public class CandidateApplicationService
    {
        private readonly ICandidateApplicationRepository _repo;
        private readonly IProgramRepository _programRepository;
        public CandidateApplicationService(ICandidateApplicationRepository repo, IProgramRepository programRepository)
        {
            _repo = repo;
            _programRepository = programRepository;
        }
        public async Task<CandidateApplication> GetCandidateApplicationByIdAsync(string id)
        {
            var response = await _repo.GetById(id);
            if (response == null) throw new NotFoundException($"Application with Id {id} not found");
            return response;
        }

        public async Task<CandidateApplication> SubmitCandidateApplicationAsync(CandidateApplication candidateApplication)
        {
            if (string.IsNullOrEmpty(candidateApplication.ProgramId)) throw new ValidationException("Program Id cannot be empty or null");
            var program = await _programRepository.GetById(candidateApplication.ProgramId);
            if (program == null) throw new NotFoundException($"Program with Id {candidateApplication.ProgramId} not found");
            candidateApplication.Id = Guid.NewGuid().ToString();
            await _repo.Add(candidateApplication);
            return candidateApplication;
        }
    }
}
