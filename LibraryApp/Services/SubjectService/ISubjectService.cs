using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
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

        Task<ICollection<LectureFile>> GetFileBySubject(int id);

        Task<ICollection<Topic>> GetTopicBySubject(int id);
        Task<FileStreamResult> DownloadFiles(int subjectId);
    }
}
