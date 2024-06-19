using CapitalPlacement.Core.Models;

namespace CapitalPlacement.Core.Interface.Services
{
    public interface IProgramService
    {
        Task<ProgramModel> CreateProgramAsync(ProgramModel program);
        Task<ProgramModel> UpdateProgramAsync(ProgramModel program);
    }
}
