using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjects();

        Task<Subject> GetSubjectById(int id);

        Task<Subject> AddSubject(Subject subject);

        Task<Subject> UpdateSubject(int id, Subject subject);

        Task<Subject> DeleteSubject(int id);
        Task<List<Subject>> Search(string searchString);
    }
}
