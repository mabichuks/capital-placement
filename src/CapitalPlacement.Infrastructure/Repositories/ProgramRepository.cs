using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;
using CapitalPlacement.Infrastructure.Database;
using CapitalPlacement.Infrastructure.Entities;
using CapitalPlacement.Infrastructure.Extensions;

namespace CapitalPlacement.Infrastructure.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosDbContext _dbContext;
        public ProgramRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProgramModel> Add(ProgramModel program)
        {
            var entity = new ProgramEntity
            {
                Id = program.Id,
                Title = program.Title,
                Questions = program.Questions.Select(x => x.ToEntity(program.Id!)).ToList()
            };
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return program;
        }

        public async Task<bool> Delete(string id)
        {
            var program = await LoadProductWithReferences(id);

            if (program == null)
            {
                return false;
            }

            _dbContext.Programs.Remove(program);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ProgramModel?> GetById(string id)
        {
            var entity = await LoadProductWithReferences(id);
            if (entity == null) return null;
            return new ProgramModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Questions = entity.Questions.Select(x => x.ToModel(id)).ToList()
            };
        }

        public async Task<ProgramModel?> Update(ProgramModel program)
        {
            var existing = await LoadProductWithReferences(program.Id!);
            if (existing == null) return null;
            existing.Title = program.Title;
            existing.Questions = program.Questions.Select(x => x.ToEntity(program.Id!)).ToList();
            await _dbContext.SaveChangesAsync();
            return program;
        }

        private async Task<ProgramEntity?> LoadProductWithReferences(string id)
        {
            var program = await _dbContext
                .Programs
                .FindAsync(id);

            if (program == null) return null;

            var programEntry = _dbContext.Programs.Entry(program);

            await programEntry
                .Collection(product => product.Questions)
                .LoadAsync();


            return program;
        }
    }
}
