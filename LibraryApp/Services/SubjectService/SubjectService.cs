using LibraryApp.Data.Model;
using LibraryApp.Services.SubjectService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {

        private readonly DataContext _context;

        public SubjectService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            return subject;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {

            var existSubject = await _context.Subjects.FirstOrDefaultAsync(x => x.Name == subject.Name);

            if (existSubject != null)
            {
                throw new Exception("Subject already exist");
            }

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubject(int id, Subject subject)
        {
            var subjectUpdate = await _context.Subjects.FindAsync(id);

            subjectUpdate.SubjectCode = subject.SubjectCode;
            subjectUpdate.Name = subject.Name;
            subjectUpdate.Description = subject.Description;

            await _context.SaveChangesAsync();

            return subjectUpdate;
        }

        public async Task<Subject> DeleteSubject(int id)
        {

            var subject = await _context.Subjects.FindAsync(id);

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<List<Subject>> Search(string searchString)
        {
            var subject = from s in _context.Subjects
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                subject = subject.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.SubjectCode.ToLower().Contains(searchString.ToLower()));
            }

            return await subject.ToListAsync();
        }
    }
}
