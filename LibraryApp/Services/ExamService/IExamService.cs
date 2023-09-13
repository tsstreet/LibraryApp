using LibraryApp.Data.Dto;
using LibraryApp.Data.Model;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.ExamService
{
    public interface IExamService
    {
        Task<List<Exam>> GetExams();

        Task<Exam> GetExamById(int id);

        Task<Exam> CreateExam(ExamDto exam);

        Task<Exam> UpdateExam(int id, Exam exam);

        Task<Exam> DeleteExam(int id);
        Task<List<Exam>> Search(string searchString);
        Task<Exam> Approve(int id);

        Task<Exam> UnApprove(int id);
    }
}
