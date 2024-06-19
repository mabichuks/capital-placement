using CapitalPlacement.Core.Models;

namespace CapitalPlacement.Core.Interface.Repositories
{
    public interface IProgramRepository
    {
        Task<ProgramModel> Add(ProgramModel program);
        Task<ProgramModel?> Update(ProgramModel program);
        Task<ProgramModel?> GetById(string id);
        Task<bool> Delete(string id);
    }
}
