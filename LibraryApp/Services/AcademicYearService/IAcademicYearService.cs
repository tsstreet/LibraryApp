using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.AcademicYearService
{
    public interface IAcademicYearService
    {
        Task<List<AcademicYear>> GetAcademicYears();

        Task<AcademicYear> GetAcademicYearById(int id);

        Task<AcademicYear> AddAcademicYear(AcademicYear academicYear);

        Task<AcademicYear> UpdateAcademicYear(int id, AcademicYear academicYear);

        Task<AcademicYear> DeleteAcademicYear(int id);

        Task<ICollection<Class>> GetClassByAcademicYear(int id);

        Task<List<AcademicYear>> Search(string searchString);
    }
}
