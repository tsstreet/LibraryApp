using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
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

        Task<string> RenameLectureFile(int id, string reName);

        Task<string> UploadLectureFile(LectureFile lectureFile);

        Task<FileDownloadResult> DownloadFile(int lectureFileId);

    }
}
