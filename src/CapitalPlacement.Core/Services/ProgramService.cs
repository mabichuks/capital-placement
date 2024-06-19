using CapitalPlacement.Core.Exceptions;
using CapitalPlacement.Core.Interface.Repositories;
using CapitalPlacement.Core.Models;

namespace CapitalPlacement.Core.Services
{
    public class ProgramService
    {
        private readonly IProgramRepository _repo;
        public ProgramService(IProgramRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProgramModel> CreateProgram(ProgramModel model)
        {
            model.Id = Guid.NewGuid().ToString();
            await _repo.Add(model);
            return model;
        }

        public async Task<ProgramModel?> UpdateQuestions(ProgramModel model)
        {
            var result = await _repo.Update(model);
            if (result == null) throw new NotFoundException($"Entitiy with id {model.Id} not found");
            return model;
        }

        public async Task<ProgramModel?> GetById(string id)
        {
            var result = await _repo.GetById(id);
            if (result == null) throw new NotFoundException($"Entitiy with id {id} not found");
            return result;
        }

        public async Task Delete(string id)
        {
            var isSuccessful = await _repo.Delete(id);
            if (!isSuccessful) throw new NotFoundException($"Entitiy with id {id} not found");
        }
    }
}
