using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.LectureFileService
{
    public interface ILectureFileService
    {
        Task<List<LectureFile>> GetLectureFiles();

        Task<LectureFile> GetLectureFileById(int id);

        //Task<Subject> AddSubject(Subject subject);

        //Task<Subject> UpdateSubject(int id, Subject subject);

        Task<LectureFile> DeleteLectureFile(int id);
        Task<List<LectureFile>> Search(string searchString);

        //Task<string> CreateLectureFile(LectureFile lectureFile);

        Task<string> CreateLectureFile(LectureFile lectureFile);
    }
}
