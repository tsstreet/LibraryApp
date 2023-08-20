using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.FalcutyService
{
    public interface IFalcutyService
    {
        Task<List<Falcuty>> GetFalcuties();

        Task<Falcuty> GetFalcutyById(int id);

        Task<Falcuty> AddFalcuty(Falcuty falcuty);

        Task<Falcuty> UpdateFalcuty(int id, Falcuty falcuty);

        Task<Falcuty> DeleteFalcuty(int id);

        Task<List<Falcuty>> Search(string searchString);

        Task<ICollection<Subject>> GetSubjectByFalcuty(int id);
    }
}
