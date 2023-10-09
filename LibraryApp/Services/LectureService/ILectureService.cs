using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.LectureService
{
    public interface ILectureService
    {
        Task<List<Lecture>> GetLectures();

        Task<Lecture> GetLectureById(int id);

        //Task<Subject> AddSubject(Subject subject);

        //Task<Subject> UpdateSubject(int id, Subject subject);

        Task<Lecture> DeleteLecture(int id);
        Task<List<Lecture>> Search(string searchString);

        //Task<string> CreateLectureFile(LectureFile lectureFile);

        Task<string> RenameLectureFile(int id, string reName);

        Task<string> UploadLecture(Lecture lectureFile);

        Task<FileDownloadResult> DownloadFile(int lectureFileId);

    }
}
