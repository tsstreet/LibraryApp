using LibraryApp.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryApp.Services.SubjectGradeService
{
    public class SubjectGradeService : ISubjectGradeService
    {

        private readonly DataContext _context;

        public SubjectGradeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SubjectGrade>> GetSubjectGrades()
        {
            return await _context.SubjectGrades.ToListAsync();
        }

        public async Task<SubjectGrade> GetSubjectGradeById(int id)
        {
            var schedule = await _context.SubjectGrades.FindAsync(id);

            return schedule;
        }

        public async Task<SubjectGrade> AddSubjectGrade(SubjectGrade subjectGrade)
        {
            _context.SubjectGrades.Add(subjectGrade);
            await _context.SaveChangesAsync();
            return subjectGrade;
        }

        public async Task<SubjectGrade> UpdateSubjectGrade(int id, SubjectGrade subjectGrade)
        {
            var subjectGradeUpdate = await _context.SubjectGrades.FindAsync(id);

            subjectGradeUpdate.SubjectId = subjectGrade.SubjectId;
            subjectGradeUpdate.AcademicYearId = subjectGrade.AcademicYearId;
            subjectGradeUpdate.GradeTypeId = subjectGrade.GradeTypeId;
            subjectGradeUpdate.NumOfGradeColumn = subjectGrade.NumOfGradeColumn;
            subjectGradeUpdate.NumOfRequireGradeColumn = subjectGrade.NumOfRequireGradeColumn;

            await _context.SaveChangesAsync();

            return subjectGradeUpdate;
        }

        public async Task<SubjectGrade> DeleteSubjectGrade(int id)
        {

            var subjectGradeDelete = await _context.SubjectGrades.FindAsync(id);

            _context.SubjectGrades.Remove(subjectGradeDelete);

            await _context.SaveChangesAsync();

            return subjectGradeDelete;
        }

        public async Task<List<SubjectGrade>> Search(string searchString)
        {
            var search = from s in _context.SubjectGrades
                           join t in _context.Subjects on s.SubjectId equals t.SubjectId
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                search = search.Where(s => s.Subject.Name.ToLower().Contains(searchString.ToLower()));
            }

            return await search.ToListAsync();
        }
    }
}
