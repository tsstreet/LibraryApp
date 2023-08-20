using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace LibraryApp.Services.SubjectGradeService
{
    public interface ISubjectGradeService
    {
        Task<List<SubjectGrade>> GetSubjectGrades();

        Task<SubjectGrade> GetSubjectGradeById(int id);

        Task<SubjectGrade> AddSubjectGrade(SubjectGrade subjectGrade);

        Task<SubjectGrade> UpdateSubjectGrade(int id, SubjectGrade subjectGrade);

        Task<SubjectGrade> DeleteSubjectGrade(int id);

        Task<List<SubjectGrade>> Search(string searchString);
    }
}
