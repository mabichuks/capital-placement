using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Infrastructure.Database;
using CapitalPlacement.Infrastructure.Entities;
using CapitalPlacement.Infrastructure.Extensions;

namespace CapitalPlacement.Infrastructure.Repositories
{
    public class CandidateApplicationRepository : ICandidateApplicationRepository
    {
        private readonly CosmosDbContext _dbContext;

        public CandidateApplicationRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CandidateApplication> Add(CandidateApplication candidateApplication)
        {
            var entity = new CandidateApplicationEntity
            {
                Id = candidateApplication.Id,
                Answers = candidateApplication.Answers.Select(x => x.ToEntity()).ToList()
            };

            _dbContext.CandidateApplications.Add(entity);
            await _dbContext.SaveChangesAsync();
            return candidateApplication;
        }

        public async Task<CandidateApplication?> GetById(string id)
        {
            var entity = await _dbContext.CandidateApplications.FindAsync(id);
            if (entity == null) return null;

            return new CandidateApplication
            {
                Id = entity.Id,
                Answers = entity.Answers.Select(x => x.ToModel()).ToList()
            };
        }
    }
}
